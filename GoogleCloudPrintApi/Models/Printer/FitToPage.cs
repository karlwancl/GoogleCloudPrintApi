using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Capability that defines the page fitting options available on a device.
    /// </summary>
    public class FitToPage
    {
        /// <summary>
        /// Enumeration of page fitting algorithms. The "page" is defined as the media
        /// size minus any given margins.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            NO_FITTING = 0,
            FIT_TO_PAGE = 1,
            GROW_TO_PAGE = 2,
            SHRINK_TO_PAGE = 3,
            FILL_PAGE = 4
        }

        public class Option
        {
            /// <summary>
            /// Enumeration of page fitting algorithms. The "page" is defined as the media
            /// size minus any given margins.
            /// </summary>
            public Type? Type { get; set; }

            public bool? IsDefault { get; set; }
        }

        public IList<Option> FitToPageOption { get; set; }
    }
}