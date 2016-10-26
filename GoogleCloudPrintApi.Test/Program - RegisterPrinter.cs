using GoogleCloudPrintApi.Models.Printer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Test
{
    internal partial class Program
    {
        static void RegisterPrinter()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var pq = GetSelectedQueue();
            if (pq != null)
            {
                string capabilities = GetCapabilitiesFromPrintQueue(pq);
                var request = new RegisterRequest
                {
                    Name = pq.FullName,
                    DefaultDisplayName = pq.FullName,
                    Proxy = proxy,
                    Capabilities = capabilities
                };
                var googlePrinter = client.RegisterPrinterAsync(request).Result;
                Console.WriteLine($"Success: {googlePrinter.Success}");
            }
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

        private static PrintQueue GetSelectedQueue()
        {
            var pqs = new LocalPrintServer().GetPrintQueues();
            if (pqs != null && pqs.Any())
            {
                for (int i = 0; i < pqs.Count(); i++)
                    Console.WriteLine($"{i+1}. {pqs.ElementAt(i).FullName}");
                Console.Write("Please choose a printer to register: ");
                int option = -1;
                if (int.TryParse(Console.ReadLine(), out option))
                    return pqs.ElementAt(option - 1);
            }
            else
                Console.WriteLine("There's no printer to register!");
            return null;
        }
    }
}
