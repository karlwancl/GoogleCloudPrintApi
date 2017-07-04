using GoogleCloudPrintApi.Models.Application;
using GoogleCloudPrintApi.Models.Printer;
using System;
using System.IO;
using System.Linq;

namespace GoogleCloudPrintApi.Samples
{
    internal partial class Program
    {
        private static void SubmitJob()
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
                Console.Write("Please choose a printer to submit job: ");
                if (int.TryParse(Console.ReadLine(), out printerOption))
                {
                    var printer = listResponse.Printers.ElementAt(printerOption - 1);
                    var printerRequest = new PrinterRequest { PrinterId = printer.Id };
                    var printerResponse = client.GetPrinterAsync(printerRequest).Result;
                    if (printerResponse.Printers != null && printerResponse.Printers.Any())
                    {
                        Console.Write("Do you print from Url or a local document? (Y: Url, N: Local Document)");
                        bool isUrl = Console.ReadLine().ToLower().Contains("y");
                        Console.WriteLine("Please enter the path to the url/ the local document");
                        string path = Console.ReadLine();
                        var cjt = new CloudJobTicket
                        {
                            Print = new PrintTicketSection
                            {
                                Color = new ColorTicketItem { Type = Color.Type.STANDARD_MONOCHROME },
                                Duplex = new DuplexTicketItem { Type = Duplex.Type.LONG_EDGE },
                                PageOrientation = new PageOrientationTicketItem() { Type = PageOrientation.Type.LANDSCAPE },
                                Copies = new CopiesTicketItem() { Copies = 3 }
                            }
                        };

                        JobResponse<SubmitRequest> response;
                        if (isUrl)
                        {
                            var request = new SubmitRequest
                            {
                                PrinterId = printer.Id,
                                Title = Guid.NewGuid().ToString(),
                                Ticket = cjt,
                                Content = new SubmitFileLink(path)
                            };
                            response = client.SubmitJobAsync(request).Result;
                        }
                        else
                        {
                            using (var s = File.Open(path, FileMode.Open))
                            {
                                var request = new SubmitRequest()
                                {
                                    PrinterId = printer.Id,
                                    Title = Path.GetFileNameWithoutExtension(path),
                                    Ticket = cjt,
                                    Content = new SubmitFileStream("text/plain", path, s)
                                };
                                response = client.SubmitJobAsync(request).Result;
                            }
                        }
                        Console.WriteLine("Success: {0}", response.Success);
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