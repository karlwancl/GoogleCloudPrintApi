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
    public class JobsResponse<T>: ResponseBase<T> where T: IRequest
    {
        [JsonProperty]
        public List<Job.Job> Jobs { get; private set; }
    }
}
