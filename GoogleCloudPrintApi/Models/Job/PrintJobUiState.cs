using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Job
{
    public class PrintJobUiState
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SummaryType
        {
            DRAFT = 0,
            QUEUED = 1,
            IN_PROGRESS = 2,
            PAUSED = 3,
            DONE = 4,
            CANCELLED = 5,
            ERROR = 6,
            EXPIRED = 7
        }

        [JsonProperty]
        public SummaryType Summary { get; private set; }

        [JsonProperty]
        public string Progress { get; private set; }

        [JsonProperty]
        public string Cause { get; private set; }
    }
}
