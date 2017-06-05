using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
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
            Console.WriteLine($"Token: {tokenString}");
            return token;
        }

        private static Models.Token GenerateAndSaveToken()
        {
            var url = provider.BuildAuthorizationUrl();
            Console.WriteLine($"{url} will be opened");

            var process = Process.Start("/Applications/Google Chrome.app/Contents/MacOS/Google Chrome", url);
            Console.Write("Please paste the authorization code to continue: ");

            var authCode = Console.ReadLine();
            var token = provider.GenerateRefreshTokenAsync(authCode).Result;
            SaveToken(token);
            return token;
        }

        private static void SaveToken(Models.Token token)
        {
            string tokenString = JsonConvert.SerializeObject(token);
            File.WriteAllText(TokenPath, tokenString);
            Console.WriteLine($"Token: {tokenString}");
        }
    }
}