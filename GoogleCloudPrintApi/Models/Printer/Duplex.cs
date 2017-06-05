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
        public Duplex(IList<Option> option)
        {
            DuplexOption = option;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            NO_DUPLEX = 0,
            LONG_EDGE = 1,
            SHORT_EDGE = 2
        }

        public class Option
        {
            public Option(Type type, bool is_default)
            {
                Type = type;
                IsDefault = is_default;
            }

            public Type Type { get; private set; } = Type.NO_DUPLEX;

            public bool IsDefault { get; private set; } = false;
        }

        public IList<Option> DuplexOption { get; private set; }
    }
}