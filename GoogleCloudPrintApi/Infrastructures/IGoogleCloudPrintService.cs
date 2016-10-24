using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi.Infrastructures
{
    interface IGoogleCloudPrintService
    {
        Task<DeleteResponse> DeletePrinterAsync(DeleteRequest request);

        Task<ControlResponse> UpdatePrintJobStatusAsync(ControlRequest request);

        Task<ListResponse> ListPrinterAsync(ListRequest request);

        Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request);

        Task<UpdateResponse> UpdatePrinterAsync(UpdateRequest request);

        Task<FetchResponse> FetchJobAsync(FetchRequest request);

        Task<XDocument> GetTicketAsync(string ticketUrl, string proxy);

        Task<dynamic> GetTicketv2Async(string jobId);

        Task<byte[]> GetDocumentAsync(string fileUrl, string proxy);

        Task<byte[]> GetDocumentv2Async(string fileUrl);

        // TODO: GetPrinterAsync, SharePrinterAsync, UnsharePrinterAsync
    }
}
