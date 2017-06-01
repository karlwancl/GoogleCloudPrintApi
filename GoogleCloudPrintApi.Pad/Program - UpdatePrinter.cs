using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Linq;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
        static void UpdatePrinter()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var listRequest = new ListRequest { Proxy = proxy };
            var listResponse = client.ListPrinterAsync(listRequest).Result;
            if (listResponse.Printers != null && listResponse.Printers.Any())
            {
                for (int i=0; i<listResponse.Printers.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {listResponse.Printers.ElementAt(i).DisplayName}");
                }
                Console.Write("Please choose a printer to update: ");
                int option = -1;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    var printer = listResponse.Printers.ElementAt(option - 1);
                    Console.Write("Enter a display name to update: ");
                    string updateName = Console.ReadLine();
                    var updateRequest = new UpdateRequest
                    {
                        PrinterId = printer.Id,
                        Name = updateName,
                        DisplayName =  updateName
                    };
                    var updateResponse = client.UpdatePrinterAsync(updateRequest).Result;
                    Console.WriteLine($"Update: {updateResponse.Success}");
                }
            }
            else
                Console.WriteLine("There is no printer to update!");
        }
    }
}
