using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Infrastructures;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class JobsResponse<T>: Response<T> where T: IRequest
    {
        public List<Job.Job> Jobs { get; set; }

        public Range Range { get; set; }
    }
}
