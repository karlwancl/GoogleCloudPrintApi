using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
        private static void RegisterPrinter()
        {
            try
            {
                var client = new GoogleCloudPrintClient(provider, token);
                var pqs = GetPrintQueues();

                for (int i = 0; i < pqs.Count(); i++)
                {
                    Console.WriteLine("{0}. {1}", i, pqs.ElementAt(i).Key);
                }
                Console.Write("Select 1 printer to register: ");
                int index = Convert.ToInt32(Console.ReadLine());

                var request = new RegisterRequest
                {
                    Name = pqs.ElementAt(index).Key,
                    DefaultDisplayName = pqs.ElementAt(index).Key,
                    Proxy = proxy,
                    Capabilities = File.ReadAllText(pqs.ElementAt(index).Value),
                    UseCdd = false
                };

                Console.WriteLine("Prepare to register: {0} to {1}\n{2}", request.Name, request.Proxy, request.Capabilities.Substring(0, 32));
                Console.ReadLine();
                var googlePrinter = client.RegisterPrinterAsync(request).Result;
                Console.WriteLine($"Success: {googlePrinter.Success}");
            }
            catch (System.AggregateException ex)
            {
                if (ex.InnerExceptions.Any())
                    Console.WriteLine(ex.InnerExceptions.First().Message);
            }
        }

        private static IDictionary<string, string> GetPrintQueues()
        {
            var path = Directory.GetCurrentDirectory();
            Console.WriteLine("Current Path: {0}", path);
            var files = Directory.GetFiles(Path.Combine(path, "xps")).Where(f => Path.GetExtension(f) == ".xml");
            return files.ToDictionary(f => Path.GetFileNameWithoutExtension(f), f => Path.GetFullPath(f));
        }
    }
}