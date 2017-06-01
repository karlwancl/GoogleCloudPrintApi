using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using System;
using System.Linq;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
        static void SharePrinter()
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
                Console.Write("Please choose a printer to share: ");
                if (int.TryParse(Console.ReadLine(), out printerOption))
                {
                    var printer = listResponse.Printers.ElementAt(printerOption - 1);
                    Console.Write("Please enter a google account to send share invitation: ");
                    string account = Console.ReadLine();
                    var shareRequest = new ShareRequest
                    {
                         PrinterId = printer.Id,
                         Scope = account,
                         Role = Role.USER,
                         SkipNotification = false
                    };
                    var shareResponse = client.SharePrinterAsync(shareRequest).Result;
                    if (shareResponse.Success)
                        Console.WriteLine($"Invitaion is sent to {account}");
                    else
                        Console.WriteLine($"Invitation is not sent, error: {shareResponse.Message}");
                }
            }
            else
                Console.WriteLine("There is no printer in the list");
        }

        static void UnsharePrinter()
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
                Console.Write("Please choose a printer to unshare: ");
                if (int.TryParse(Console.ReadLine(), out printerOption))
                {
                    var printer = listResponse.Printers.ElementAt(printerOption - 1);
                    Console.Write("Please enter a google account to unshare: ");
                    string account = Console.ReadLine();
                    var unshareRequest = new UnshareRequest
                    {
                        PrinterId = printer.Id,
                        Scope = account
                    };
                    var unshareResponse = client.UnsharePrinterAsync(unshareRequest).Result;
                    if (unshareResponse.Success)
                        Console.WriteLine($"Printer {printer.Name} is unshared from {account}");
                    else
                        Console.WriteLine($"Printer unshare failed, error: {unshareResponse.Message}");
                }
            }
            else
                Console.WriteLine("There is no printer in the list");
        }
    }
}
