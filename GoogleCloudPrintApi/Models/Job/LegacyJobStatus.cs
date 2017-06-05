using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Job
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LegacyJobStatus
    {
        QUEUED,
        IN_PROGRESS,
        DONE,
        ERROR,
        SUBMITTED,
        HELD
    }
}