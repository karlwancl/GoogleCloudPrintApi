using System.Collections.Generic;
using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Models.Printer;
using System;

namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitRequest 
	{
        /// <summary>
        /// Unique printer identification
        /// </summary>
		[Required]
		public string PrinterId { get; set; }

        /// <summary>
        /// Title of the print job, to be used within GCP.
        /// </summary>
		[Required]
		public string Title { get; set; }

        /// <summary>
        /// Print ticket in CJT format.
        /// </summary>
        public CloudJobTicket Ticket { get; set; }

        /// <summary>
        /// Printer capabilities (XPS or PPD)
        /// </summary>
        [Obsolete("please use 'ticket' instead")]
        public string Capabilities { get; set; }

        /// <summary>
        /// Document to print (can be a file or a string)
        /// </summary>
        [Required]
		public ISubmitFile Content { get; set; }

        /// <summary>
        /// One or more tags to add to the print job.
        /// </summary>
		public List<string> Tag { get; set; }
	}
}