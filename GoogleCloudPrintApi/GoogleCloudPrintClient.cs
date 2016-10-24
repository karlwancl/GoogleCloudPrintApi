using GoogleCloudPrintApi.Helpers;
using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models;
using GoogleCloudPrintApi.Models.Printer;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;
using GoogleCloudPrintApi.Models.Share;

namespace GoogleCloudPrintApi
{
    public class GoogleCloudPrintClient : GoogleClientBase, IGoogleCloudPrintService
    {
        protected const string GoogleCloudPrintBaseUrl = "https://www.google.com/cloudprint/";

        public GoogleCloudPrintClient(GoogleCloudPrintOAuth2Provider oAuth2Provider, Token token) : base(oAuth2Provider, token)
        {
        }

        /// <summary>
        /// Update status for the google print job
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#control
        /// </summary>
        /// <param name="request">Parameters for /control interface</param>
        /// <returns>Result for /control interface</returns>
        public async Task<ControlResponse> UpdateJobStatusAsync(ControlRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                 .Auth(_token.AccessToken)
                 .Param("jobid", request.JobId)
                 .ParamIfNotNull("semantic_state_diff", request.SemanticStateDiff)
                 .PostAsync<ControlResponse>("control"));
        }

        /// <summary>
        /// Delete printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#delete
        /// </summary>
        /// <param name="request">Parameters for /delete interface</param>
        /// <returns>Result for /delete interface</returns>
        public async Task<DeleteResponse> DeletePrinterAsync(DeleteRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl))
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .PostAsync<DeleteResponse>("delete");
        }

        /// <summary>
        /// List printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListResponse> ListPrinterAsync(ListRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("proxy", request.Proxy)
                .ParamIfNotNullOrEmpty("extra_fields", request.ExtraFields)
                .PostAsync<ListResponse>("list"));
        }

        /// <summary>
        /// Register local printer to google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#register
        /// </summary>
        /// <param name="request">Parameters for /register interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<RegisterResponse> RegisterPrinterAsync(RegisterRequest request)
        {
            await UpdateToken();

            bool isGoogleCloudPrint20 = request.GCPVersion == "2.0";

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("name", request.Name)
                .ParamIfNotNullOrEmpty("default_display_name", request.DefaultDisplayName)
                .Param("proxy", request.Proxy)
                .ParamIf("uuid", request.Uuid, isGoogleCloudPrint20)
                .ParamIf("manufacturer", request.Manufacturer, isGoogleCloudPrint20)
                .ParamIf("model", request.Model, isGoogleCloudPrint20)
                .ParamIf("gcp_version", request.GCPVersion, isGoogleCloudPrint20)
                .ParamIf("setup_url", request.SetupUrl, isGoogleCloudPrint20)
                .ParamIf("support_url", request.SupportUrl, isGoogleCloudPrint20)
                .ParamIf("update_url", request.UpdateUrl, isGoogleCloudPrint20)
                .ParamIf("firmware", request.Firmware, isGoogleCloudPrint20)
                .ParamIfNotNull("local_settings", request.LocalSettings)
                .ParamIff("use_cdd", bool.TrueString, request.UseCdd.ToString(), isGoogleCloudPrint20)
                .Param("capabilities", request.Capabilities)
                .ParamIfNotNullOrEmpty("defaults", request.Defaults)
                .ParamIfNotNullOrEmpty("capsHash", request.CapsHash)
                .ParamForEach("tag", request.Tag)
                .ParamForEach("data", request.Data)
                .PostMultipartAsync<RegisterResponse>("register"));
        }

        /// <summary>
        /// Update printer information on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#update
        /// </summary>
        /// <param name="request">Parameters for /update interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<UpdateResponse> UpdatePrinterAsync(UpdateRequest request)
        {
            await UpdateToken();

            bool isGoogleCloudPrint20 = request.GCPVersion == "2.0";

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .ParamIfNotNullOrEmpty("name", request.Name)
                .ParamIfNotNullOrEmpty("default_display_name", request.DefaultDisplayName)
                .ParamIfNotNullOrEmpty("display_name", request.DisplayName)
                .ParamIfNotNullOrEmpty("proxy", request.Proxy)
                .ParamIfNotNullOrEmpty("uuid", request.Uuid)
                .ParamIfNotNullOrEmpty("manufacturer", request.Manufacturer)
                .ParamIfNotNullOrEmpty("model", request.Model)
                .ParamIfNotNullOrEmpty("gcp_version", request.GCPVersion)
                .ParamIfNotNullOrEmpty("setup_url", request.SetupUrl)
                .ParamIfNotNullOrEmpty("support_url", request.SupportUrl)
                .ParamIfNotNullOrEmpty("update_url", request.UpdateUrl)
                .ParamIfNotNullOrEmpty("firmware", request.Firmware)
                .ParamIfNotNull("local_settings", request.LocalSettings)
                .ParamIff("use_cdd", bool.TrueString, request.UseCdd.ToString(), isGoogleCloudPrint20)
                .ParamIfNotNullOrEmpty("capabilities", request.Capabilities)
                .ParamIfNotNullOrEmpty("defaults", request.Defaults)
                .ParamIfNotNullOrEmpty("capsHash", request.CapsHash)
                .ParamForEach("tag", request.Tag)
                .ParamForEach("remove_tag", request.RemoveTag)
                .ParamForEach("data", request.Data)
                .ParamForEach("remove_data", request.RemoveData)
                .PostMultipartAsync<UpdateResponse>("update"));
        }

        /// <summary>
        /// Fetch pending print jobs from google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="request">Parameters for /fetch interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<FetchResponse> FetchJobAsync(FetchRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .PostAsync<FetchResponse>("fetch"));
        }

        /// <summary>
        /// Return print ticket document for the print job (for GCP 1.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="ticketUrl">The URL of the print ticket document</param>
        /// <param name="proxy">The print proxy id</param>
        /// <returns>The print ticket document</returns>
        public async Task<XDocument> GetTicketAsync(string ticketUrl, string proxy)
        {
            await UpdateToken();

            string ticket = await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Header("X-CloudPrint-Proxy", proxy)
                .GetAsync());

            return XDocument.Parse(ticket);
        }

        /// <summary>
        /// Return print ticket in Cloud Job Ticket (CJT) format for the print job (for GCP 2.0, currently not implemented since the need of cdd)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="jobId">The id of the job</param>
        /// <returns>The print ticket</returns>
        public Task<dynamic> GetTicketv2Async(string jobId)
        {
            throw new NotImplementedException("Use GCP 1.0 instead since GCP 2.0 requires CDD document for the printer");
        }

        /// <summary>
        /// Return downloaded file for the print job (for GCP 1.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="fileUrl">The URL of the file</param>
        /// <param name="proxy">The print proxy id</param>
        /// <returns>The downloaded file</returns>
        public async Task<byte[]> GetDocumentAsync(string fileUrl, string proxy)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Accept("application/pdf")
                .Header("X-CloudPrint-Proxy", proxy)
                .ExecuteBytesAsync());
        }

        /// <summary>
        /// Return downloaded file for the print job (for GCP 2.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="fileUrl">The URL of the file</param>
        /// <returns>The downloaded file</returns>
        public Task<byte[]> GetDocumentv2Async(string fileUrl)
        {
            throw new NotImplementedException("Use GCP 1.0 instead since GCP 2.0 requires CDD document for the printer");
        }

        /// <summary>
        /// Get printer detail
        /// reference: https://developers.google.com/cloud-print/docs/appInterfaces#printer
        /// </summary>
        /// <param name="request">Parameters for /printer interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<PrinterResponse> GetPrinterAsync(PrinterRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .Param("use_cdd", request.UseCdd.ToString())
                .Param("extra_fields", request.ExtraFields)
                .PostAsync<PrinterResponse>("printer"));
        }

        /// <summary>
        /// Share google cloud printer to other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#share
        /// </summary>
        /// <param name="request">Parameters for /share interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<ShareResponse> SharePrinterAsync(ShareRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .Param("scope", request.Scope)
                .Param("role", request.Role.ToString().ToUpper())
                .ParamIf("skip_notification", request.SkipNotification.ToString(), request.SkipNotification)
                .PostAsync<ShareResponse>("share"));
        }

        /// <summary>
        /// Unshare google cloud printer from other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#unshare
        /// </summary>
        /// <param name="request">Parameters for /unshare interface</param>
        /// <returns>Response from google cloud</returns>
        public async Task<UnshareResponse> UnsharePrinterAsync(UnshareRequest request)
        {
            await UpdateToken();

            return await (new EasyRestClient(GoogleCloudPrintBaseUrl)
                .Auth(_token.AccessToken)
                .Param("printerid", request.PrinterId)
                .Param("scope", request.Scope)
                .PostAsync<UnshareResponse>("unshare"));
        }
    }
}