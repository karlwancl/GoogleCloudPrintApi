using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class FetchResponse
    {
        public FetchResponse(bool success, dynamic request, string xsrf_token, List<Job.Job> jobs)
        {
            Success = success;
            Request = request;
            XsrfToken = xsrf_token;
            Jobs = jobs;
        }

        public bool Success { get; private set; }

        [PartiallySupported("Parse json dynamically")]
        public dynamic Request { get; private set; }

        public string XsrfToken { get; private set; }

        public List<Job.Job> Jobs { get; private set; }
    }
}
