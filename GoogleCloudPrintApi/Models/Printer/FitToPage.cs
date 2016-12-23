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
        public FitToPage(IList<Option> option)
        {
            FitToPageOption = option;
        }

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
            public Option(Type type, bool is_default)
            {
                Type = type;
                IsDefault = is_default;
            }

            /// <summary>
            /// Enumeration of page fitting algorithms. The "page" is defined as the media
            /// size minus any given margins.
            /// </summary>
            public Type Type { get; private set; }

            public bool IsDefault { get; private set; } = false;
        }

        public IList<Option> FitToPageOption { get; private set; }
    }

}
