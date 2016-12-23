using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Capability that defines the page orientation options available on a device.
    /// </summary>
    public class PageOrientation
    {
        public PageOrientation(IList<Option> option)
        {
            PageOrientationOption = option;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            PORTRAIT = 0,
            LANDSCAPE = 1,
            AUTO = 2
        }

        public class Option
        {
            public Option(Type type, bool is_default)
            {
                Type = type;
                IsDefault = is_default;
            }

            /// <summary>
            /// Type of page orientation (required).
            /// </summary>
            public Type Type { get; private set; }

            public bool IsDefault { get; private set; } = false;
        }

        public IList<Option> PageOrientationOption { get; private set; }
    }

}
