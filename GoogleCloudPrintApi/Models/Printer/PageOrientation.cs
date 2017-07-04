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
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            PORTRAIT = 0,
            LANDSCAPE = 1,
            AUTO = 2
        }

        public class Option
        {
            /// <summary>
            /// Type of page orientation (required).
            /// </summary>
            public Type? Type { get; set; }

            public bool? IsDefault { get; set; }
        }

        public IList<Option> PageOrientationOption { get; set; }
    }
}