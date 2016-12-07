using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class ControlResponse
    {
        public ControlResponse(bool success,string message, string xsrf_token, dynamic request, Job.Job job)
        {
            Success = success;
            Message = message;
            XsrfToken = xsrf_token;
            Request = request;
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
