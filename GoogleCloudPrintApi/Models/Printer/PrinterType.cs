using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrinterType
    {
        GOOGLE,
        HP,
        DOCS,
        DRIVE,
        FEDEX,
        ANDROID_CHROME_SNAPSHOT,
        IOS_CHROME_SNAPSHOT
    }
}