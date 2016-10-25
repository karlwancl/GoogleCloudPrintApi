using GoogleCloudPrintApi.Models.Printer;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Printing;

namespace GoogleCloudPrintApi.Test
{
    internal partial class Program
    {
        private const string ClientId = "1043593901426-7puk1uucb5qmgac8cnnocv48qivaptvv.apps.googleusercontent.com";
        private const string ClientSecret = "NSdjucZucgNdLl9eANIswkXJ";
        private const string TokenPath = "token.txt";
        private const string ProxyPath = "proxy.txt";
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
                Console.WriteLine("1. List Printers");
                Console.WriteLine("2. Update Printers");
                Console.WriteLine("3. Delete Printer");
                Console.Write("Select an operation: ");
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            RegisterPrinter();
                            break;
                        case 1:
                            ListPrinter();
                            break;
                        case 2:
                            UpdatePrinter();
                            break;
                        case 3:
                            DeletePrinter();
                            break;
                    }
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("Please input a number!");
            }
            Console.ReadLine();
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
    }
}