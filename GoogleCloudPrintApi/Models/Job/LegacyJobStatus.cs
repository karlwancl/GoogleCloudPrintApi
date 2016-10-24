using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
