using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi.Infrastructures
{
    interface IGoogleCloudPrintService
    {
        Task<DeleteResponse> DeletePrinterAsync(DeleteRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<ControlResponse> UpdateJobStatusAsync(ControlRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<ListResponse> ListPrinterAsync(ListRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<UpdateResponse> UpdatePrinterAsync(UpdateRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<FetchResponse> FetchJobAsync(FetchRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<XDocument> GetTicketAsync(string ticketUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

        Task<CloudJobTicket> GetCloudJobTicketAsync(TicketRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<Stream> GetDocumentAsync(string fileUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

        Task<Stream> GetDocumentv2Async(string fileUrl, CancellationToken cancellationToken = default(CancellationToken));

        Task<PrinterResponse> GetPrinterAsync(PrinterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<ShareResponse> SharePrinterAsync(ShareRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<UnshareResponse> UnsharePrinterAsync(UnshareRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
