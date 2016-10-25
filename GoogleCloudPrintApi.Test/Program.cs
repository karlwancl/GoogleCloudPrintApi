using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Printing;
using GoogleCloudPrintApi.Models.Printer;

namespace GoogleCloudPrintApi.Test
{
    class Program
    {
        const string ClientId = "1043593901426-7puk1uucb5qmgac8cnnocv48qivaptvv.apps.googleusercontent.com";
        const string ClientSecret = "NSdjucZucgNdLl9eANIswkXJ";
        const string TokenPath = "token.txt";
        const string ProxyPath = "proxy.txt";
        static readonly GoogleCloudPrintOAuth2Provider provider = new GoogleCloudPrintOAuth2Provider(ClientId, ClientSecret);

        static void Main(string[] args)
        {
            Models.Token token = File.Exists(TokenPath) ? ReadTokenFromFile() : GenerateAndSaveToken();
           var proxy =  GetProxy();

            var client = new GoogleCloudPrintClient(provider, token);
            var pq = GetFirstPrintQueue();
            Console.WriteLine($"{pq.Description}");

            if (pq != null)
            {
                string queueName = pq.Name;
                string capabilities = GetCapabilitiesFromPrintQueue(pq);
                var request = new RegisterRequest
                {
                    Name = queueName,
                    Proxy = proxy,
                    Capabilities = capabilities
                };
                var googlePrinter = client.RegisterPrinterAsync(request).Result;
                Console.WriteLine($"Success: {googlePrinter.Success}");
            }

            Console.ReadLine();
        }

        static string GetProxy()
        {
            string proxy = Guid.NewGuid().ToString();
            if (File.Exists(ProxyPath))
                proxy = File.ReadAllText(ProxyPath);
            else
                File.WriteAllText(ProxyPath, proxy);
            return proxy;
        }

        private static string GetCapabilitiesFromPrintQueue(PrintQueue pq)
        {
            string cap = null;
            using (var ms = pq.GetPrintCapabilitiesAsXml())
            using (var sr = new StreamReader(ms))
            {
                cap = sr.ReadToEnd();
            }
            return cap;
        }

        private static PrintQueue GetFirstPrintQueue()
        {
            return (new LocalPrintServer().GetPrintQueues().FirstOrDefault());
        }

        private static Models.Token ReadTokenFromFile()
        {
            Models.Token token = null;
            string tokenString = "";

            using (var fs = File.OpenRead(TokenPath))
            using (var sr = new StreamReader(fs))
            {
                tokenString = sr.ReadToEnd();
                token = JsonConvert.DeserializeObject<Models.Token>(tokenString);
            }
            Console.WriteLine($"Token is read: {tokenString}");
            return token;
        }

        private static Models.Token GenerateAndSaveToken()
        {
            var url = provider.BuildAuthorizationUrl();
            Console.WriteLine($"{url} will be opened");

            var process = Process.Start("chrome.exe", url);
            Console.Write("Please paste the authorization code to continue: ");

            var authCode = Console.ReadLine();
            var token = provider.GenerateRefreshTokenAsync(authCode).Result;
            File.WriteAllText(TokenPath, JsonConvert.SerializeObject(token));
            return token;
        }
    }
}
