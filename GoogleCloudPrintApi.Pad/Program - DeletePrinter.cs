using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Linq;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
        static void DeletePrinter()
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
                Console.Write("Please choose a printer to delete: ");
                int option = -1;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    var printer = listResponse.Printers.ElementAt(option - 1);
                    var deleteRequest = new DeleteRequest { PrinterId = printer.Id };
                    var deleteResponse = client.DeletePrinterAsync(deleteRequest).Result;
                    Console.WriteLine($"Delete: {deleteResponse.Success}");
                }
            }
            else
                Console.WriteLine("There is no printer to delete!");
        }
    }
}
