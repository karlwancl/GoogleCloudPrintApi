using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrintJobStateDiff : IJsonSerializable
    {
        public PrintJobStateDiff(JobState state, int pages_printed)
        {
            State = state;
            PagesPrinted = pages_printed;
        }

        [JsonProperty("state")]
        public JobState State { get; private set; }

        [JsonProperty("pages_printed")]
        public int PagesPrinted { get; private set; }
    }
}
