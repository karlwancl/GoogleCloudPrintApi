using System.Collections.Generic;
using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Models.Printer;
using System;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitRequest: ISubmitFileRequest
	{
        /// <summary>
        /// Unique printer identification
        /// </summary>
		[FormKey(isRequiredFor: VersionOption.All)]
		public string PrinterId { get; set; }

        /// <summary>
        /// Title of the print job, to be used within GCP.
        /// </summary>
		[FormKey(isRequiredFor: VersionOption.All)]
		public string Title { get; set; }

        /// <summary>
        /// Print ticket in CJT format.
        /// </summary>
        [FormKey(isRequiredFor: VersionOption.All)]
        public CloudJobTicket Ticket { get; set; }

        /// <summary>
        /// Printer capabilities (XPS or PPD)
        /// </summary>
        [FormKey, Obsolete("please use 'ticket' instead")]
        public string Capabilities { get; set; }

        /// <summary>
        /// Document to print (can be a file or a string)
        /// </summary>
        [FormKey(isRequiredFor: VersionOption.All)]
		public ISubmitFile Content { get; set; }

        /// <summary>
        /// One or more tags to add to the print job.
        /// </summary>
        [FormKey]
		public List<string> Tag { get; set; }
	}
}