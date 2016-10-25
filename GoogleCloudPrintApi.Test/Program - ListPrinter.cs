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
        static void ListPrinter()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var request = new ListRequest { Proxy = proxy };
            var response = client.ListPrinterAsync(request).Result;
            if (response.Printers != null && response.Printers.Any())
            {
                for (int i = 0; i < response.Printers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {response.Printers.ElementAt(i).DisplayName}");
                }
            }
            else
                Console.WriteLine("There is no printer in the list");
        }
    }
}
