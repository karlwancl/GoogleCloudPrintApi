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
        static void FetchJob()
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

                // Choose printer
                Console.Write("Please choose a printer to fetch job: ");
                int printerOption = -1;
                if (int.TryParse(Console.ReadLine(), out printerOption))
                {
                    var printer = listResponse.Printers.ElementAt(printerOption - 1);

                    var fetchRequest = new FetchRequest { PrinterId = printer.Id };
                    var fetchResponse = client.FetchJobAsync(fetchRequest).Result;
                    if (fetchResponse.Success && fetchResponse.Jobs.Any())
                    {
                        for (int i = 0; i < fetchResponse.Jobs.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {fetchResponse.Jobs.ElementAt(i).Title}");
                        }

                        // Choose job on specific printer
                        Console.Write("Please choose a print job to download: ");
                        int printJobOption = -1;
                        if (int.TryParse(Console.ReadLine(), out printJobOption))
                        {
                            if (printJobOption == -1)
                                return;
                            var printJob = fetchResponse.Jobs.ElementAt(printJobOption - 1);
                            if (DownloadTicket(client, printJob) && DownloadDocument(client, printJob))
                            {
                                var updateRequest = new ControlRequest
                                {
                                    JobId = printJob.Id,
                                    Status = Models.Job.LegacyJobStatus.DONE
                                };
                                var updateResponse = client.UpdateJobStatusAsync(updateRequest).Result;
                                Console.WriteLine($"Update job status: {updateResponse.Success}");
                            }

                        }
                        else
                            Console.WriteLine("Fail to choose print job");
                    }
                    else
                        Console.WriteLine("There is currently no job!");
                }
            }
            else
                Console.WriteLine("There is no printer to delete!");
        }

        private static bool DownloadDocument(GoogleCloudPrintClient client, Models.Job.Job printJob)
        {
            try
            {
                using (var documentStream = client.GetDocumentAsync(printJob.FileUrl, proxy).Result)
                {
                    Directory.CreateDirectory(DocumentFolderPath);
                    string path = $"{Path.Combine(DocumentFolderPath, Path.GetFileNameWithoutExtension(printJob.Title))}.pdf";
                    using (var fs = File.Create(path))
                    {
                        documentStream.CopyTo(fs);
                    }
                }
                Console.WriteLine($"Document {printJob.Title} is saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        private static bool DownloadTicket(GoogleCloudPrintClient client, Models.Job.Job printJob)
        {
            try
            {
                var ticket = client.GetTicketAsync(printJob.TicketUrl, proxy).Result;
                Directory.CreateDirectory(TicketFolderPath);
                string path = $"{Path.Combine(TicketFolderPath, Path.GetFileNameWithoutExtension(printJob.Title))}.xml";
                ticket.Save(path);
                Console.WriteLine($"Ticket {printJob.Title} is saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
