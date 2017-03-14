using System.Collections.Generic;
using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Models.Printer;

namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitRequest 
	{
		[Required]
		public string PrinterId { get; set; }

		[Required]
		public string Title { get; set; }
		
		[Required]
		public BaseSubmitFile Content { get; set; }

		public CloudJobTicket Ticket { get; set; }

		public List<string> Tag { get; set; }
	}
}