using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CapabilitiesFormat
    {
        CDD,
        XPS,
        PPD
    }
}