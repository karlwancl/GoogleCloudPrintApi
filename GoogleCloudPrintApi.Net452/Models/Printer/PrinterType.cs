using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
