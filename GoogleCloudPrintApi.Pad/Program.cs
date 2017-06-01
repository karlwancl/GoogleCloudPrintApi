using System;
using System.IO;

namespace GoogleCloudPrintApi.Pad
{
    partial class Program
    {
		private const string ClientId = "1043593901426-7puk1uucb5qmgac8cnnocv48qivaptvv.apps.googleusercontent.com";
		private const string ClientSecret = "NSdjucZucgNdLl9eANIswkXJ";
		private const string TokenPath = "token.txt";
		private const string ProxyPath = "proxy.txt";
		private const string TicketFolderPath = "ticket";
		private const string DocumentFolderPath = "document";
		private static readonly GoogleCloudPrintOAuth2Provider provider = new GoogleCloudPrintOAuth2Provider(ClientId, ClientSecret);
		static Models.Token token = null;
		static string proxy = null;

		private static void Main(string[] args)
		{
			token = File.Exists(TokenPath) ? ReadTokenFromFile() : GenerateAndSaveToken();
			//token = GenerateAndSaveToken();
			proxy = GetProxy();

			int option = 0;
			while (option != -1)
			{
				Console.WriteLine("0. Register Printer");
				Console.WriteLine("1. Get Printer");
				Console.WriteLine("2. Update Printers");
				Console.WriteLine("3. Delete Printer");
				Console.WriteLine("4. Fetch and download print job");
				Console.WriteLine("5. Share Printer");
				Console.WriteLine("6. Unshare Printer");
				Console.WriteLine("7. Test Only");
				Console.WriteLine("8. Xmpp Testing");
				Console.Write("Select an operation: ");
				if (int.TryParse(Console.ReadLine(), out option))
				{
					switch (option)
					{
						case 0:
							RegisterPrinter();
							break;
						case 1:
							ListAndGetPrinter();
							break;
						case 2:
							UpdatePrinter();
							break;
						case 3:
							DeletePrinter();
							break;
						case 4:
							FetchJob();
							break;
						case 5:
							SharePrinter();
							break;
						case 6:
							UnsharePrinter();
							break;
						case 7:
							Test();
							break;
						case 8:
							XmppTest();
							break;
					}
				}
				else
					Console.WriteLine("Please input a number!");
				Console.WriteLine("Press \"Enter\" to continue...");
				Console.ReadLine();
				Console.Clear();
			}
			Console.ReadLine();
		}

		private static async void XmppTest()
		{
			var client = new GoogleCloudPrintClient(provider, token);
			client.OnXmppDebugLogging += Client_OnXmppLogging;
			client.OnIncomingPrintJobs += Client_OnIncomingPrintJobs;
			client.OnTokenUpdated += Client_OnTokenUpdated;
			await client.InitXmppAsync("salmonthinlion");
			//client.StopXmppAndCleanup();
		}

		private static void Client_OnTokenUpdated(object sender, Models.Token e)
		{
			SaveToken(e);
		}

		private static void Client_OnIncomingPrintJobs(object sender, JobRecievedEventArgs e)
		{
			Console.WriteLine(e.PrinterId);
		}

		private static void Client_OnXmppLogging(object sender, string e)
		{
			Console.WriteLine(e);
		}

		private static string GetProxy()
		{
			string proxy = Guid.NewGuid().ToString();
			if (File.Exists(ProxyPath))
				proxy = File.ReadAllText(ProxyPath);
			else
				File.WriteAllText(ProxyPath, proxy);
			Console.WriteLine($"Proxy: {proxy}");
			return proxy;
		}

		private static void Test()
		{
			var googClient = new GoogleCloudPrintClient(provider, token);

			using (var client = new WebClient())
			{
				client.Headers.Add("X-CloudPrint-Proxy", proxy);
				var authToken = googClient.GetTokenAsync().Result.AccessToken;
				client.Headers.Add("Authorization", string.Format("Bearer {0}", authToken));
				client.OpenRead("https://www.google.com/cloudprint/download?id=71a1c2f9-62a8-884a-a673-114db79b87bf");
				var bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
				Console.WriteLine(bytes_total.ToString() + " Bytes");
			}
		}
    }
}
