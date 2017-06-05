using GoogleCloudPrintApi.Models.Application;
using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi.Infrastructures
{
    internal interface IGoogleCloudPrintService
    {
        Task<Response<DeleteRequest>> DeletePrinterAsync(DeleteRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<Response<ShareRequest>> SharePrinterAsync(ShareRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<Response<UnshareRequest>> UnsharePrinterAsync(UnshareRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<JobResponse<ControlRequest>> UpdateJobStatusAsync(ControlRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<JobResponse<SubmitRequest>> SubmitJobAsync(SubmitRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<JobsResponse<FetchRequest>> FetchJobAsync(FetchRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<PrintersResponse<PrinterRequest>> GetPrinterAsync(PrinterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<PrinterResponse<UpdateRequest>> UpdatePrinterAsync(UpdateRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<PrintersResponse<ListRequest>> ListPrinterAsync(ListRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<PrintersResponse<SearchRequest>> SearchPrinterAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<XDocument> GetTicketAsync(string ticketUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

        Task<Stream> GetDocumentAsync(string fileUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

        Task<CloudJobTicket> GetCloudJobTicketAsync(TicketRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}