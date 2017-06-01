using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Job
{
    public class PrintJobState
    {
        [JsonProperty]
        public string Version { get; private set; }

        [JsonProperty]
        public JobState State { get; private set; }

        [JsonProperty]
        public int PagesPrinted { get; private set; }

        [JsonProperty]
        public int DeliveryAttempts { get; private set; }
    }
}
