using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Linq;
using System.Text;

namespace GoogleCloudPrintApi.Samples
{
    internal partial class Program
    {
        private static void ListAndGetPrinter()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var listRequest = new ListRequest { Proxy = proxy };
            var listResponse = client.ListPrinterAsync(listRequest).Result;
            if (listResponse.Printers != null && listResponse.Printers.Any())
            {
                for (int i = 0; i < listResponse.Printers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listResponse.Printers.ElementAt(i).DisplayName}");
                }
                int printerOption = -1;
                Console.Write("Please choose a printer to look for details: ");
                if (int.TryParse(Console.ReadLine(), out printerOption))
                {
                    var printer = listResponse.Printers.ElementAt(printerOption - 1);
                    var printerRequest = new PrinterRequest { PrinterId = printer.Id };
                    var printerResponse = client.GetPrinterAsync(printerRequest).Result;
                    if (printerResponse.Printers != null && printerResponse.Printers.Any())
                    {
                        var thePrinter = printerResponse.Printers.ElementAt(0);
                        var message = new StringBuilder()
                            .AppendLine($"Printer: {thePrinter.Name}")
                            .AppendLine($"Model: {thePrinter.Model}")
                            .ToString();
                        Console.WriteLine(message);
                    }
                    else
                        Console.WriteLine("No relevant printer is found.");
                }
            }
            else
                Console.WriteLine("There is no printer in the list");
        }
    }
}