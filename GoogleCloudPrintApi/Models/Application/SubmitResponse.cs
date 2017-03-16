using System.Collections.Generic;
using GoogleCloudPrintApi.Attributes;

namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitResponse
	{
		public SubmitResponse(bool success, string xsrf_token, string message, dynamic request, Job.Job job) {
			Success = success;
			XsrfToken = xsrf_token;
			Request = request;
			Message = message;
			Job = job;
		}

		public bool Success { get; private set; }

		public string Message { get; private set; }

		public string XsrfToken { get; private set; }

		[PartiallySupported("Parse json dynamically")]
		public dynamic Request { get; private set; }

		public Job.Job Job { get; private set; }
	}
}