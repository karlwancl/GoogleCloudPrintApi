using GoogleCloudPrintApi.Models.Application;
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
        Task<ResponseBase<DeleteRequest>> DeletePrinterAsync(DeleteRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<ResponseBase<ShareRequest>> SharePrinterAsync(ShareRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<ResponseBase<UnshareRequest>> UnsharePrinterAsync(UnshareRequest request, CancellationToken cancellationToken = default(CancellationToken));


        Task<JobResponse<ControlRequest>> UpdateJobStatusAsync(ControlRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<JobResponse<SubmitRequest>> SubmitJobAsync(SubmitRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<JobsResponse<FetchRequest>> FetchJobAsync(FetchRequest request, CancellationToken cancellationToken = default(CancellationToken));


		Task<PrinterResponse<PrinterRequest>> GetPrinterAsync(PrinterRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<PrinterResponse<UpdateRequest>> UpdatePrinterAsync(UpdateRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<PrintersResponse<ListRequest>> ListPrinterAsync(ListRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<PrintersResponse<SearchRequest>> SearchAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken));


		Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<XDocument> GetTicketAsync(string ticketUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> GetDocumentAsync(string fileUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken));

        Task<CloudJobTicket> GetCloudJobTicketAsync(TicketRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
