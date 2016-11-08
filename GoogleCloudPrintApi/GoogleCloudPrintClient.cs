using Flurl;
using Flurl.Http;
using GoogleCloudPrintApi.Exception;
using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models;
using GoogleCloudPrintApi.Models.Printer;
using GoogleCloudPrintApi.Models.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoogleCloudPrintApi
{
    // For use in server application only
    // TODO: Support other different platforms
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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result for /control interface</returns>
        public async Task<ControlResponse> UpdateJobStatusAsync(ControlRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            var form = new Dictionary<string, string>();
            form.Add("jobid", request.JobId);
            if (request.SemanticStateDiff == null)
            {
                form.Add("status", request.Status.ToString());
                form.Add("code", request.Code);
                form.Add("message", request.Message);
            }
            else
                form.Add("semantic_state_diff", request.SemanticStateDiff.ToJson());

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("control")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(form, cancellationToken)
                .ReceiveJsonButThrowIfFails<ControlResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Delete printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#delete
        /// </summary>
        /// <param name="request">Parameters for /delete interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result for /delete interface</returns>
        public async Task<DeleteResponse> DeletePrinterAsync(DeleteRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("delete")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(new { printerid = request.PrinterId }, cancellationToken)
                .ReceiveJsonButThrowIfFails<DeleteResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// List printer on google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#list
        /// </summary>
        /// <param name="request">Parameters for /list interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<ListResponse> ListPrinterAsync(ListRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            var form = new Dictionary<string, string>();
            form.Add("proxy", request.Proxy);
            if (!string.IsNullOrEmpty(request.ExtraFields)) form.Add("extra_fields", request.ExtraFields);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("list")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(form, cancellationToken)
                .ReceiveJsonButThrowIfFails<ListResponse>()
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
            await UpdateToken(cancellationToken);

            bool isGoogleCloudPrint20 = request.GCPVersion == "2.0";

            var form = new Dictionary<string, string>();
            form.Add("name", request.Name);
            if (!string.IsNullOrEmpty(request.DefaultDisplayName)) form.Add("default_display_name", request.DefaultDisplayName);
            form.Add("proxy", request.Proxy);
            if (isGoogleCloudPrint20)
            {
                form.Add("uuid", request.Uuid);
                form.Add("manufacturer", request.Manufacturer);
                form.Add("model", request.Model);
                form.Add("gcp_version", request.GCPVersion);
                form.Add("setup_url", request.SetupUrl);
                form.Add("support_url", request.SupportUrl);
                form.Add("update_url", request.UpdateUrl);
                form.Add("firmware", request.Firmware);
                form.Add("use_cdd", true.ToString());
            }
            else
                form.Add("use_cdd", request.UseCdd.ToString());
            if (request.LocalSettings != null) form.Add("local_settings", request.LocalSettings.ToJson());
            form.Add("capabilities", request.Capabilities);
            if (!string.IsNullOrEmpty(request.Defaults)) form.Add("defaults", request.Defaults);
            if (!string.IsNullOrEmpty(request.CapsHash)) form.Add("capsHash", request.CapsHash);
            if (request.Tag != null)
                foreach (var tag in request.Tag)
                    form.Add("tag", tag);
            if (request.Data != null)
                foreach (var data in request.Data)
                    form.Add("data", data);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("register")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostMultipartAsync(multipart => multipart.AddStringParts(form), cancellationToken)
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
        public async Task<UpdateResponse> UpdatePrinterAsync(UpdateRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            bool isGoogleCloudPrint20 = request.GCPVersion == "2.0";

            var form = new Dictionary<string, string>();
            form.Add("printerid", request.PrinterId);
            if (!string.IsNullOrEmpty(request.Name)) form.Add("name", request.Name);
            if (!string.IsNullOrEmpty(request.DefaultDisplayName)) form.Add("default_display_name", request.DefaultDisplayName);
            if (!string.IsNullOrEmpty(request.DisplayName)) form.Add("display_name", request.DisplayName);
            if (!string.IsNullOrEmpty(request.Proxy)) form.Add("proxy", request.Proxy);
            if (!string.IsNullOrEmpty(request.Uuid)) form.Add("uuid", request.Uuid);
            if (!string.IsNullOrEmpty(request.Manufacturer)) form.Add("manufacturer", request.Manufacturer);
            if (!string.IsNullOrEmpty(request.Model)) form.Add("model", request.Model);
            if (!string.IsNullOrEmpty(request.GCPVersion)) form.Add("gcp_version", request.GCPVersion);
            if (!string.IsNullOrEmpty(request.SetupUrl)) form.Add("setup_url", request.SetupUrl);
            if (!string.IsNullOrEmpty(request.SupportUrl)) form.Add("support_url", request.SupportUrl);
            if (!string.IsNullOrEmpty(request.UpdateUrl)) form.Add("update_url", request.UpdateUrl);
            if (!string.IsNullOrEmpty(request.Firmware)) form.Add("firmware", request.Firmware);
            if (request.LocalSettings != null) form.Add("local_settings", request.LocalSettings.ToJson());
            form.Add("use_cdd", isGoogleCloudPrint20 ? true.ToString() : request.UseCdd.ToString());
            if (!string.IsNullOrEmpty(request.Capabilities)) form.Add("capabilities", request.Capabilities);
            if (!string.IsNullOrEmpty(request.Defaults)) form.Add("defaults", request.Defaults);
            if (!string.IsNullOrEmpty(request.CapsHash)) form.Add("capsHash", request.CapsHash);
            if (request.Tag != null)
                foreach (var tag in request.Tag)
                    form.Add("tag", tag);
            if (request.RemoveTag != null)
                foreach (var removeTag in request.RemoveTag)
                    form.Add("remove_tag", removeTag);
            if (request.Data != null)
                foreach (var data in request.Data)
                    form.Add("data", data);
            if (request.RemoveData != null)
                foreach (var removeData in request.RemoveData)
                    form.Add("remove_data", removeData);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("update")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostMultipartAsync(multipart => multipart.AddStringParts(form), cancellationToken)
                .ReceiveJsonButThrowIfFails<UpdateResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Fetch pending print jobs from google cloud
        /// reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="request">Parameters for /fetch interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<FetchResponse> FetchJobAsync(FetchRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("fetch")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(new { printerid = request.PrinterId }, cancellationToken)
                .ReceiveJsonButThrowIfFails<FetchResponse>()
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
            await UpdateToken(cancellationToken);

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
        /// <param name="jobId">The id of the job</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The print ticket</returns>
        public Task<dynamic> GetTicketv2Async(string jobId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException("Use GCP 1.0 instead since GCP 2.0 requires CDD document for the printer");
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
            await UpdateToken(cancellationToken);

            return await fileUrl
                .WithOAuthBearerToken(_token.AccessToken)
                .WithHeader("X-CloudPrint-Proxy", proxy)
                .WithHeader("Accept", "application/pdf")
                .GetStreamAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Return downloaded file for the print job (for GCP 2.0)
        /// Reference: https://developers.google.com/cloud-print/docs/proxyinterfaces#fetch
        /// </summary>
        /// <param name="fileUrl">The URL of the file</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The downloaded file</returns>
        public Task<Stream> GetDocumentv2Async(string fileUrl, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException("Use GCP 1.0 instead since GCP 2.0 requires CDD document for the printer");
        }

        /// <summary>
        /// Get printer detail
        /// reference: https://developers.google.com/cloud-print/docs/appInterfaces#printer
        /// </summary>
        /// <param name="request">Parameters for /printer interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<PrinterResponse> GetPrinterAsync(PrinterRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            var form = new Dictionary<string, string>();
            form.Add("printerid", request.PrinterId);
            if (!string.IsNullOrEmpty(request.Client)) form.Add("client", request.Client);
            if (!string.IsNullOrEmpty(request.ExtraFields)) form.Add("extra_fields", request.ExtraFields);
            form.Add("use_cdd", request.UseCdd.ToString());
            if (request.PrinterConnectionStatus) form.Add("printer_connection_status", request.PrinterConnectionStatus.ToString());

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("printer")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(form, cancellationToken)
                .ReceiveJsonButThrowIfFails<PrinterResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Share google cloud printer to other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#share
        /// </summary>
        /// <param name="request">Parameters for /share interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<ShareResponse> SharePrinterAsync(ShareRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            var form = new Dictionary<string, string>();
            form.Add("printerid", request.PrinterId);
            form.Add("scope", request.Scope);
            form.Add("role", request.Role.ToString().ToUpper());
            if (request.SkipNotification) form.Add("skip_notification", request.SkipNotification.ToString());

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("share")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(form, cancellationToken)
                .ReceiveJsonButThrowIfFails<ShareResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Unshare google cloud printer from other google user
        /// reference: https://developers.google.com/cloud-print/docs/shareApi#unshare
        /// </summary>
        /// <param name="request">Parameters for /unshare interface</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from google cloud</returns>
        public async Task<UnshareResponse> UnsharePrinterAsync(UnshareRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateToken(cancellationToken);

            return await GoogleCloudPrintBaseUrl
                .AppendPathSegment("unshare")
                .WithOAuthBearerToken(_token.AccessToken)
                .PostUrlEncodedAsync(new
                {
                    printerid = request.PrinterId,
                    scope = request.Scope
                }, cancellationToken)
                .ReceiveJsonButThrowIfFails<UnshareResponse>()
                .ConfigureAwait(false);
        }
    }
}