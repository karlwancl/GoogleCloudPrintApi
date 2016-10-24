using GoogleCloudPrintApi.Models.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Job
{
    public class Job
    {
        public Job(string id, string printerid, string printerName, string title, string contentType, string fileUrl,
            string rasterUrl, string ticketUrl, long createTime, long updateTime, PrintJobState semanticState,
            PrintJobUiState uiState, LegacyJobStatus status, string errorCode, string message,
            List<string> tags, string ownerId, int numberOfPages, PrinterType printerType, string driveUrl)
        {
            Id = id;
            PrinterId = printerid;
            PrinterName = printerName;
            Title = title;
            ContentType = contentType;
            FileUrl = fileUrl;
            RasterUrl = rasterUrl;
            TicketUrl = ticketUrl;
            CreateTime = createTime;
            UpdateTime = updateTime;
            SemanticState = semanticState;
            UiState = uiState;
            Status = status;
            ErrorCode = errorCode;
            Message = message;
            Tags = tags;
            OwnerId = ownerId;
            NumberOfPages = numberOfPages;
            PrinterType = printerType;
            DriveUrl = driveUrl;
        }

        /// <summary>
        /// print job's GCP ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// printer's GCP ID
        /// </summary>
        public string PrinterId { get; private set; }

        /// <summary>
        /// printer's display name
        /// </summary>
        public string PrinterName { get; private set; }

        /// <summary>
        /// document title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// document content type (MIME type)
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// URL where the document data can be accessed while the print job is active
        /// </summary>
        public string FileUrl { get; private set; }

        /// <summary>
        /// URL where the document data (in pwg-raster format) can be accessed while the print job is active
        /// </summary>
        public string RasterUrl { get; private set; }

        /// <summary>
        /// (deprecated, please use the /ticket interface instead): URL where the print job's ticket can be accessed
        /// </summary>
        [Obsolete("still required for gcp1 print jobs")]
        public string TicketUrl { get; private set; }

        /// <summary>
        /// timestamp of when the print job was created
        /// </summary>
        public long CreateTime { get; private set; }

        /// <summary>
        /// timestamp of when the print job state was last updated
        /// </summary>
        public long UpdateTime { get;private  set; }

        /// <summary>
        /// state of the print job in Print Job State format
        /// </summary>
        public PrintJobState SemanticState { get; private set; }

        /// <summary>
        /// print job's Print Job UI State, which is a form of of Print Job State localized for the authenticated user and convenient for display in a UI
        /// </summary>
        public PrintJobUiState UiState { get;private  set; }

        /// <summary>
        /// Legacy job status
        /// </summary>
        [Obsolete]
        public LegacyJobStatus Status { get; private set; }

        /// <summary>
        /// error code string or integer if the status is ERROR
        /// </summary>
        [ Obsolete]
        public string ErrorCode { get; private set; }

        /// <summary>
        /// error message string if the status is ERROR
        /// </summary>
        [Obsolete]
        public string Message { get; private set; }

        /// <summary>
        /// array of free-form strings – print jobs are tagged as ^own if the user is the owner (submitter) of the job, and ^shared if the job was merely shared with the user
        /// </summary>
        public List<string> Tags { get; private set; }

        /// <summary>
        /// email address of print job's owner (submitter)
        /// </summary>
        public string OwnerId { get; private set; }

        /// <summary>
        /// number of pages in the document
        /// </summary>
        public int NumberOfPages { get; private set; }

        /// <summary>
        /// printer's type (see the /search interface for possible types)
        /// </summary>
        public PrinterType PrinterType { get; private set; }

        /// <summary>
        /// URL of the saved PDF in Google Drive if printerType is DRIVE and the job completed successfully
        /// </summary>
        public string DriveUrl { get; private set; }
    }
}
