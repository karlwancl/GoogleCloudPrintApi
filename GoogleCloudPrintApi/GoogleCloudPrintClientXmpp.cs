using GoogleCloudPrintApi.Exception;
using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models;
using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GoogleCloudPrintApi
{
    /// <summary>
    /// Code here is contributed by [@Jezternz](https://github.com/Jezternz)
    /// </summary>
    public partial class GoogleCloudPrintClient
    {
        // Consts
        private const string xmppServerHost = "talk.google.com";
        private const int xmppServerPort = 5223;

        // Stream / Connection
        private TcpClient _xmppTcpClient = null;

        private SslStream _xmppSslStream = null;

        // Stream logging for initial connect
        private string ConnectConversation { get; set; }

        // Handler for incoming job events
        public event EventHandler<JobRecievedEventArgs> OnIncomingPrintJobs;

        // Handler for debug logging
        public event EventHandler<string> OnXmppDebugLogging;

        #region Constructor & Cleanup

        public void StopXmppAndCleanup()
        {
            OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Closing & Cleaning up socket connection with google.");
            // Cleanup stream & client
            if (_xmppSslStream != null)
            {
                _xmppSslStream.Dispose();
                _xmppSslStream = null;
            }
            if (_xmppTcpClient != null)
            {
                _xmppTcpClient.Dispose();
                _xmppTcpClient = null;
            }
        }

        #endregion Constructor & Cleanup

        #region Main Connection Creation

        public async Task InitXmppAsync(string xmppJid)
        {
            await UpdateTokenAsync().ConfigureAwait(false);
            ConnectConversation = "\n[ConversationBegin]\n";
            try
            {
                OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Opening new socket connection with google.");

                // Setup socket connection
                _xmppTcpClient = new TcpClient();
                await _xmppTcpClient.ConnectAsync(xmppServerHost, xmppServerPort);

                // Setup SSL Wrapper
                var tcpStream = _xmppTcpClient.GetStream();
                _xmppSslStream = new SslStream(tcpStream, false, new RemoteCertificateValidationCallback((s, c, ch, ss) => true), null);

                // Authenticate
                await _xmppSslStream.AuthenticateAsClientAsync(xmppServerHost);

                // Begin conversation with google
                // 1st initial stream request
                await SendAsync("<stream:stream to=\"gmail.com\" xml:lang=\"en\" version=\"1.0\" xmlns:stream=\"http://etherx.jabber.org/streams\" xmlns=\"jabber:client\">").ConfigureAwait(false);
                var streamResp11 = await RecieveAsync().ConfigureAwait(false);
                var streamResp12 = await RecieveAsync().ConfigureAwait(false);

                OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Authenticating with google.");

                // Authenticate using Oauth2
                var authB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"\0{xmppJid}\0{_token.AccessToken}"));
                await SendAsync("<auth xmlns=\"urn:ietf:params:xml:ns:xmpp-sasl\" mechanism=\"X-OAUTH2\" auth:service=\"oauth2\" xmlns:auth=\"http://www.google.com/talk/protocol/auth\">{0}</auth>", authB64).ConfigureAwait(false);
                var authResp = await RecieveXmlAsync().ConfigureAwait(false);
                if (authResp == null || authResp.GetElementsByTagName("success").Count < 1)
                    throw new GoogleCloudPrintException($"Xmpp Connection - Authentication failed, xmpp conversation: '{ConnectConversation}'.");

                // 2nd stream request (now authenticated)
                await SendAsync("<stream:stream to=\"gmail.com\" xml:lang=\"en\" version=\"1.0\" xmlns:stream=\"http://etherx.jabber.org/streams\" xmlns=\"jabber:client\">").ConfigureAwait(false);
                var streamResp21 = await RecieveAsync().ConfigureAwait(false);
                var streamResp22 = await RecieveAsync().ConfigureAwait(false);

                OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Subscribing to google cloud print events...");

                // Bind Request (to retrieve jid)
                await SendAsync("<iq type=\"set\" id=\"0\"><bind xmlns=\"urn:ietf:params:xml:ns:xmpp-bind\"><resource>cloud_print</resource></bind></iq>").ConfigureAwait(false);
                var bindResp = await RecieveXmlAsync().ConfigureAwait(false);
                if (bindResp == null)
                    throw new GoogleCloudPrintException($"Xmpp Connection - Bind failed, xmpp conversation: '{ConnectConversation}'.");

                var fullJid = bindResp.GetElementsByTagName("jid")[0].InnerText;
                var bareJid = fullJid.Substring(0, fullJid.IndexOf('/'));

                // Establish session
                await SendAsync("<iq type=\"set\" id=\"2\"><session xmlns=\"urn:ietf:params:xml:ns:xmpp-session\"/></iq>").ConfigureAwait(false);
                var sessionResp1 = await RecieveAsync().ConfigureAwait(false);
                var sessionResp2 = await RecieveAsync().ConfigureAwait(false);

                // Use jid to now subscribe to google cloud print events
                await SendAsync("<iq type=\"set\" id=\"3\" to=\"{0}\"><subscribe xmlns=\"google:push\"><item channel=\"cloudprint.google.com\" from=\"cloudprint.google.com\"/></subscribe></iq>", bareJid).ConfigureAwait(false);
                var subscribeResp = await RecieveAsync().ConfigureAwait(false);

                OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Established connection to google and Subscribed to events successfully.");

                // Finally begin asynchronously listening for events
                new Task(async () =>
                {
                    // Re-init the handshake if the loop is not manually break
                    if (!await ListenForIncomingJobsAsync().ConfigureAwait(false))
                        await InitXmppAsync(xmppJid).ConfigureAwait(false);
                }).Start();

                OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Ready.");
            }
            catch (GoogleCloudPrintException ex)
            {
                StopXmppAndCleanup();
                OnXmppDebugLogging?.Invoke(this, ex.Message);
                throw ex;
            }
            catch (System.Exception ex)
            {
                StopXmppAndCleanup();
                var message = $"Xmpp Connection - Exception occured while attempting to establish secure stream with google exception: '{ex.Message}', conversation: '{ConnectConversation}'";
                OnXmppDebugLogging?.Invoke(this, message);
                throw new GoogleCloudPrintException(message);
            }
        }

        #endregion Main Connection Creation

        #region Main Listen Loop

        /// <summary>
        /// Listener loop for subscribing google talk events
        /// </summary>
        /// <returns>Returns if the loop is manually break or not</returns>
        private async Task<bool> ListenForIncomingJobsAsync()
        {
            // Async task to listen to google stream for new additions to joblist
            OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Listener loop started.");

            // Only end when _xmppSslStream is cleaned up (set to null)
            while (_xmppSslStream != null)
            {
                try
                {
                    OnXmppDebugLogging?.Invoke(this, $"Xmpp Connection - Ping at '{DateTime.Now.ToUniversalTime()}'");
                    // Asnynchronously wait for new xml incoming from google
                    var xmlDoc = await RecieveXmlAsync().ConfigureAwait(false);
                    if (xmlDoc != null && OnIncomingPrintJobs != null)
                    {
                        // If xml node matches 'push:data', it must contain incoming printjob notification from google
                        var pushData = xmlDoc.GetElementsByTagName("push:data");
                        if (pushData.Count > 0)
                        {
                            // Retrieve printerId & Log
                            var printerIdEncoded = pushData[0].InnerText;
                            var printerId = Encoding.UTF8.GetString(Convert.FromBase64String(printerIdEncoded));
                            OnXmppDebugLogging?.Invoke(this, $"Xmpp Connection: Recieved job addition event from printer '{printerId}'");

                            OnIncomingPrintJobs?.Invoke(this, new JobRecievedEventArgs { PrinterId = printerId });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    OnXmppDebugLogging?.Invoke(this, $"Xmpp Connection - An Exception was thrown while listening to google, the listener loop is terminated. Exception: '{ex.Message}'");
                    StopXmppAndCleanup();
                    return false;
                }
            }

            OnXmppDebugLogging?.Invoke(this, "Xmpp Connection - Listener loop ended.");
            return true;
        }

        #endregion Main Listen Loop

        #region connection read & write methods

        private async Task SendAsync(string message, params object[] values)
        {
            // Asynchronously send message to google
            if (values.Length > 0) message = string.Format(message, values);
            ConnectConversation += string.Format("> {0}\n\n", message);
            var streamWriter = new StreamWriter(_xmppSslStream, Encoding.UTF8);
            await streamWriter.WriteLineAsync(message);
            await streamWriter.FlushAsync();
        }

        private async Task<string> RecieveAsync()
        {
            // Asynchronously recieve message from google
            var streamReader = new StreamReader(_xmppSslStream, Encoding.UTF8);
            var bytesRead = 0;
            var xmlString = string.Empty;
            char[] buffer = new char[1024];
            bytesRead = await streamReader.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 1 && buffer[0] == ' ') bytesRead = 0;
            xmlString += (new string(buffer)).Substring(0, bytesRead);
            ConnectConversation += string.Format("< {0}\n\n", xmlString);
            return xmlString;
        }

        private async Task<XmlDocument> RecieveXmlAsync()
        {
            // asynchrnously recieve message from google & parse as xml if possible.
            var xmlString = await RecieveAsync();
            if (xmlString.Length <= 1) return null;
            var strFormat = xmlString.Contains("<stream:stream") ? "{0}</stream:stream>" : "<stream:stream xmlns:stream=\"http://etherx.jabber.org/streams\">{0}</stream:stream>";
            var validXmlString = string.Format(strFormat, xmlString);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(validXmlString);
            }
            catch (System.Exception ex)
            {
                OnXmppDebugLogging?.Invoke(this, $"Xmpp Connection - Failed to parse xml '{validXmlString}' with error '{ex.Message}', instead returning null as recieved XML...");
                return null;
            }
            return xmlDoc;
        }

        #endregion connection read & write methods
    }

    public class JobRecievedEventArgs : EventArgs
    {
        public string PrinterId { get; set; }
    }
}