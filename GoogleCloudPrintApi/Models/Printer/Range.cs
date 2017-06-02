using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class Range
    {
        [JsonProperty("jobsTotal")]
        public string JobsTotal { get; set; }

        [JsonProperty("jobsCount")]
        public int JobsCount { get; set; }
    }
}