using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Capability that defines the color options available on a device.
    /// </summary>
    public class Color
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            STANDARD_COLOR = 0,
            STANDARD_MONOCHROME = 1,
            CUSTOM_COLOR = 2,
            CUSTOM_MONOCHROME = 3,
            AUTO = 4
        }

        public class OptionType
        {
            /// <summary>
            /// ID to help vendor identify the color option (required for options of type CUSTOM_COLOR and CUSTOM_MONOCHROME).
            /// </summary>
            public string VendorId { get;  set; }

            /// <summary>
            /// Type of color option used in UIs to differentiate color and non-color
            /// options (required). Note that there can be any number of options of type
            /// CUSTOM_COLOR and CUSTOM_MONOCHROME, but there should be at most one
            /// option of each of the other types.
            /// </summary>
            public Type? Type { get;  set; }

            /// <summary>
            /// Non-localized user-friendly string that represents this option.
            /// New CDDs should use custom_display_name_localized instead. It is required
            /// that either custom_display_name or custom_display_name_localized is set
            /// for options of type CUSTOM_COLOR and CUSTOM_MONOCHROME. Options of each
            /// of the other types will have their display name localized by the server.
            /// </summary>
            public string CustomDisplayName { get;  set; }

            /// <summary>
            /// Whether this option should be selected by default. Only one option
            /// should be set as default.
            /// </summary>
            public bool? IsDefault { get;  set; }

            /// <summary>
            /// Translations of custom display name of the option.
            /// If not empty, must contain an entry with locale == EN.
            /// </summary>
            public IList<LocalizedString> CustomDisplayNameLocalized { get;  set; }
        }

        public IList<OptionType> Option { get;  set; }
    }
}