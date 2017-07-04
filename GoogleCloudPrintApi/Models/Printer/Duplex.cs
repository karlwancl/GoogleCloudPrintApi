using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Capability that defines the duplexing options available on a device.
    /// </summary>
    public class Duplex
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            NO_DUPLEX = 0,
            LONG_EDGE = 1,
            SHORT_EDGE = 2
        }

        public class Option
        {
            public Type? Type { get; set; }

            public bool? IsDefault { get; set; }
        }

        public IList<Option> DuplexOption { get; set; }
    }
}