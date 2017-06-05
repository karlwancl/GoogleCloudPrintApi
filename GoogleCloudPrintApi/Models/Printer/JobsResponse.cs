using GoogleCloudPrintApi.Infrastructures;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class JobsResponse<T> : Response<T> where T : IRequest
    {
        public List<Job.Job> Jobs { get; set; }

        public Range Range { get; set; }
    }
}