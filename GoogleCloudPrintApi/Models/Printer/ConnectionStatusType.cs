using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConnectionStatusType
    {
        ONLINE,
        UNKNOWN,
        OFFLINE,
        DORMANT
    }
}