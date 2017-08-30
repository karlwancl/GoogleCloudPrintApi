using Flurl;
using Flurl.Http;
using GoogleCloudPrintApi.Exception;
using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models;
using GoogleCloudPrintApi.Models.Application;
using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi
{
    public partial class GoogleCloudPrintClient : GoogleClientBase, IGoogleCloudPrintService
    {
        protected const string GoogleCloudPrintBaseUrl = "https://www.google.com/cloudprint/";
        protected const string GoogleCloudUserProfileUrl = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json";

        public GoogleCloudPrintClient(GoogleCloudPrintOAuth2Provider oAuth2Provider, Token token) : base(oAuth2Provider, token)
        {
            FlurlHttp.Configure(c =>
            {
                c.JsonSerializer = new Flurl.Http.Configuration.NewtonsoftJsonSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() },
                    NullValueHandling = NullValueHandling.Ignore
                });
            });
        }

        /// <summary>
        /// Update status for the google print job
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#control
        /// </summary>
        /// <param name="request">Parameters for /control interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result for /control interface</returns>
        public async Task<JobResponse<ControlRequest>> UpdateJobStatusAsync(ControlRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("control")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<JobResponse<ControlRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Delete printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#delete
        /// </summary>
        /// <param name="request">Parameters for /delete interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result for /delete interface</returns>
        public async Task<Response<DeleteRequest>> DeletePrinterAsync(DeleteRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("delete")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<Response<DeleteRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// List printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#list
        /// </summary>
        /// <param name="request">Parameters for /list interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<PrintersResponse<ListRequest>> ListPrinterAsync(ListRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("list")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<PrintersResponse<ListRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Register local printer to google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#register
        /// </summary>
        /// <param name="request">Parameters for /register interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            // use_cdd parameter must set to true if google cloud print version is 2.0
            request.UseCdd = request.GCPVersion == "2.0" || request.UseCdd;

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("register")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken, true)
                .ReceiveJsonButThrowIfFails<RegisterResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Update printer information on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#update
        /// </summary>
        /// <param name="request">Parameters for /update interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<PrinterResponse<UpdateRequest>> UpdatePrinterAsync(UpdateRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            // use_cdd parameter must set to true if google cloud print version is 2.0
            request.UseCdd = request.GCPVersion == "2.0" || request.UseCdd;

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("update")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken, true)
                .ReceiveJsonButThrowIfFails<PrinterResponse<UpdateRequest>>()
                .ConfigureAwait(false);
        }
 
        /// <summary>
        /// List print jobs from google cloud
        /// reference: https://developers.google.com/cloud-print/docs/appInterfaces#jobs
        /// </summary>
        /// <param name="request">Parameters for /jobs interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<JobsResponse<JobListRequest>> ListJobAsync(JobListRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);
 
            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("jobs")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<JobsResponse<JobListRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch pending print jobs from google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="request">Parameters for /fetch interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<JobsResponse<FetchRequest>> FetchJobAsync(FetchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("fetch")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<JobsResponse<FetchRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Return print ticket document for the print job (for GCP 1.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="ticketUrl">The URL of the print ticket document</param>
        /// <param name="proxy">The print proxy id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The print ticket document</returns>
        public async Task<XDocument> GetTicketAsync(string ticketUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            string ticket = await ticketUrl
                .WithOAuthBearerToken(_token.AccessToken)
                .WithHeader("X-CloudPrint-Proxy", proxy)
                .GetStringAsync(cancellationToken)
                .ConfigureAwait(false);

            return XDocument.Parse(ticket);
        }

        /// <summary>
        /// Return print ticket in Cloud Job Ticket (CJT) format for the print job (for GCP 2.0, currently not implemented since the need of cdd)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="request">The ticket request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The print ticket</returns>
        public async Task<CloudJobTicket> GetCloudJobTicketAsync(TicketRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("ticket")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<CloudJobTicket>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Return downloaded file for the print job (for GCP 1.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="fileUrl">The URL of the file</param>
        /// <param name="proxy">The print proxy id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The downloaded file</returns>
        public async Task<Stream> GetDocumentAsync(string fileUrl, string proxy, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await fileUrl
                .WithOAuthBearerToken(_token.AccessToken)
                .WithHeader("X-CloudPrint-Proxy", proxy)
                .WithHeader("Accept", "application/pdf")
                .GetStreamAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get printer detail
        /// reference: https://developers.google.com/cloud-print/docs/appInterfaces#printer
        /// </summary>
        /// <param name="request">Parameters for /printer interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<PrintersResponse<PrinterRequest>> GetPrinterAsync(PrinterRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("printer")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<PrintersResponse<PrinterRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Share google cloud printer to other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#share
        /// </summary>
        /// <param name="request">Parameters for /share interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<Response<ShareRequest>> SharePrinterAsync(ShareRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("share")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<Response<ShareRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Unshare google cloud printer from other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#unshare
        /// </summary>
        /// <param name="request">Parameters for /unshare interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<Response<UnshareRequest>> UnsharePrinterAsync(UnshareRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("unshare")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<Response<UnshareRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Send print jobs to the GCP service
        /// </summary>
        /// <param name="request">Parameters for /submit interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
		public async Task<JobResponse<SubmitRequest>> SubmitJobAsync(SubmitRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("submit")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostMultipartAsync(mp =>
                {
                    // Basic information
                    mp.AddString("printerid", request.PrinterId)
                      .AddString("title", request.Title);

                    // Print information
                    if (request.Ticket != null)
                        mp.AddJson("ticket", request.Ticket);
                    else if (!string.IsNullOrEmpty(request.Capabilities))
                        mp.AddString("capabilities", request.Capabilities);

                    // Document information
                    if (request.Content is SubmitFileStream file)
                        mp.AddFile("content", file.File, file.FileName, file.ContentType)
                          .AddString("contentType", file.ContentType);
                    else if (request.Content is SubmitFileLink link)
                        mp.AddString("content", link.Link)
                          .AddString("contentType", "url");
                    else
                        throw new GoogleCloudPrintException("Invalid file provided");

                    // Tags
                    if (request.Tag != null)
                        foreach (var tag in request.Tag)
                            mp.AddString("tag", tag);
                }, cancellationToken)
                .ReceiveJsonButThrowIfFails<JobResponse<SubmitRequest>>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// The /search interface returns a list of printers accessible to the authenticated user, filtered by various search options.
        /// </summary>
        /// <param name="request">Parameters for /search interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
		public async Task<PrintersResponse<SearchRequest>> SearchPrinterAsync(SearchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("search")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostRequestAsync(request, cancellationToken)
                .ReceiveJsonButThrowIfFails<PrintersResponse<SearchRequest>>()
                .ConfigureAwait(false);
        }

        public async Task<UserProfile> GetUserProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);

            return await GoogleCloudUserProfileUrl
                .WithOAuthBearerToken(_token.AccessToken)
                .GetAsync(cancellationToken)
                .ReceiveJsonButThrowIfFails<UserProfile>()
                .ConfigureAwait(false);
        }
    }
}