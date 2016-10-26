using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi.Infrastructures
{
    interface IGoogleCloudPrintService
    {
        Task<DeleteResponse> DeletePrinterAsync(DeleteRequest request);

        Task<ControlResponse> UpdateJobStatusAsync(ControlRequest request);

        Task<ListResponse> ListPrinterAsync(ListRequest request);

        Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request);

        Task<UpdateResponse> UpdatePrinterAsync(UpdateRequest request);

        Task<FetchResponse> FetchJobAsync(FetchRequest request);

        Task<XDocument> GetTicketAsync(string ticketUrl, string proxy);

        Task<dynamic> GetTicketv2Async(string jobId);

        Task<Stream> GetDocumentAsync(string fileUrl, string proxy);

        Task<Stream> GetDocumentv2Async(string fileUrl);

        Task<PrinterResponse> GetPrinterAsync(PrinterRequest request);

        Task<ShareResponse> SharePrinterAsync(ShareRequest request);

        Task<UnshareResponse> UnsharePrinterAsync(UnshareRequest request);
    }
}
