using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Initializer
{
    class Program
    {
		const string ClientId = "125548135131-6ge2gii5efpsc429qh9rrtst11fs170j.apps.googleusercontent.com";
		const string ClientSecret = "diYPHKvQ3VeCt_ky8LFQlvFS";
		public static readonly GoogleCloudPrintOAuth2Provider OAuth2Provider = new GoogleCloudPrintOAuth2Provider(ClientId, ClientSecret);

		public const string RefreshTokenPath = "token.txt";
		public const string ProxyPath = "proxy.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Initializer starts...");
            var initializer = new Program();
            initializer.GenerateRefreshToken();
            initializer.GenerateProxy();
            Console.WriteLine("Process completed! Please copy the token.txt & proxy.txt to the root folder of test project");
        }

		/// <summary>
		/// Generates the refresh token. Should be called manually before testing. 
		/// </summary>
		public void GenerateRefreshToken()
		{
			var pathMap = new Dictionary<OSPlatform, string>
			{
				{OSPlatform.Windows, "chrome.exe"},
				{OSPlatform.OSX, "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome"},
				{OSPlatform.Linux, "/usr/bin/google-chrome"}
			};

			var url = OAuth2Provider.BuildAuthorizationUrl("http://127.0.0.1");
			var path = pathMap[pathMap.First(p => RuntimeInformation.IsOSPlatform(p.Key)).Key];
			var process = Process.Start(path, url);

			Console.Write("Please paste the authorization code to continue: ");
			var authCode = Console.ReadLine();

			var token = OAuth2Provider.GenerateRefreshTokenAsync(authCode, "http://127.0.0.1").Result;
			File.WriteAllText(RefreshTokenPath, JsonConvert.SerializeObject(token));
		}

		/// <summary>
		/// Generates the proxy. Should be called manually before testing
		/// </summary>
		public void GenerateProxy()
		{
			var proxy = Guid.NewGuid().ToString();
			File.WriteAllText(ProxyPath, proxy);
		}

	}
}
