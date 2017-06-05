using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

        public SummaryType Summary { get; set; }

        public string Progress { get; set; }

        public string Cause { get; set; }
    }
}