using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Job
{
    public class Job
    {
        /// <summary>
        /// print job's GCP ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// printer's GCP ID
        /// </summary>
        [JsonProperty("printerId")]
        public string PrinterId { get; set; }

        /// <summary>
        /// printer's display name
        /// </summary>
        [JsonProperty("printerName")]
        public string PrinterName { get; set; }

        /// <summary>
        /// document title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// document content type (MIME type)
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// URL where the document data can be accessed while the print job is active
        /// </summary>
        [JsonProperty("fileUrl")]
        public string FileUrl { get; set; }

        /// <summary>
        /// URL where the document data (in pwg-raster format) can be accessed while the print job is active
        /// </summary>
        [JsonProperty("rasterUrl")]
        public string RasterUrl { get; set; }

        /// <summary>
        /// (deprecated, please use the /ticket interface instead): URL where the print job's ticket can be accessed
        /// </summary>
        [JsonProperty("ticketUrl"), Obsolete("still required for gcp1 print jobs")]
        public string TicketUrl { get; set; }

        /// <summary>
        /// timestamp of when the print job was created
        /// </summary>
        [JsonProperty("createTime")]
        public long CreateTime { get; set; }

        /// <summary>
        /// timestamp of when the print job state was last updated
        /// </summary>
        [JsonProperty("updateTime")]
        public long UpdateTime { get;private  set; }

        /// <summary>
        /// state of the print job in Print Job State format
        /// </summary>
        [JsonProperty("semanticState")]
        public PrintJobState SemanticState { get; set; }

        /// <summary>
        /// print job's Print Job UI State, which is a form of of Print Job State localized for the authenticated user and convenient for display in a UI
        /// </summary>
        [JsonProperty("uiState")]
        public PrintJobUiState UiState { get;private  set; }

        /// <summary>
        /// Legacy job status
        /// </summary>
        [Obsolete]
        public LegacyJobStatus Status { get; set; }

        /// <summary>
        /// error code string or integer if the status is ERROR
        /// </summary>
        [JsonProperty("errorCode"), Obsolete]
        public string ErrorCode { get; set; }

        /// <summary>
        /// error message string if the status is ERROR
        /// </summary>
        [Obsolete]
        public string Message { get; set; }

        /// <summary>
        /// array of free-form strings – print jobs are tagged as ^own if the user is the owner (submitter) of the job, and ^shared if the job was merely shared with the user
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// email address of print job's owner (submitter)
        /// </summary>
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// number of pages in the document
        /// </summary>
        [JsonProperty("numberOfPages")]
        public int NumberOfPages { get; set; }

        /// <summary>
        /// printer's type (see the /search interface for possible types)
        /// </summary>
        [JsonProperty("printerType")]
        public PrinterType PrinterType { get; set; }

        /// <summary>
        /// URL of the saved PDF in Google Drive if printerType is DRIVE and the job completed successfully
        /// </summary>
        [JsonProperty("driveUrl")]
        public string DriveUrl { get; set; }
    }
}
