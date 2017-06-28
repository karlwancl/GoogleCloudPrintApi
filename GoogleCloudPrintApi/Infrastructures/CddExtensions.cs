using System;
using GoogleCloudPrintApi.Models.Printer;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Infrastructures
{
    public static class CddExtensions
    {
        public static string ToJson(this CloudDeviceDescription cdd)
            => JsonConvert.SerializeObject(cdd);
    }
}
