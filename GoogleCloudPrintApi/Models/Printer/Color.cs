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
        public Color(IList<Option> option)
        {
            ColorOption = option;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            STANDARD_COLOR = 0,
            STANDARD_MONOCHROME = 1,
            CUSTOM_COLOR = 2,
            CUSTOM_MONOCHROME = 3,
            AUTO = 4
        }

        public class Option
        {
            public Option(string vendor_id, Type type, string custom_display_name, bool is_default, IList<LocalizedString> custom_display_name_localized)
            {
                VendorId = vendor_id;
                Type = type;
                CustomDisplayName = custom_display_name;
                IsDefault = is_default;
                CustomDisplayNameLocalized = custom_display_name_localized;
            }

            /// <summary>
            /// ID to help vendor identify the color option (required for options of type CUSTOM_COLOR and CUSTOM_MONOCHROME).
            /// </summary>
            public string VendorId { get; private set; }

            /// <summary>
            /// Type of color option used in UIs to differentiate color and non-color 
            /// options (required). Note that there can be any number of options of type
            /// CUSTOM_COLOR and CUSTOM_MONOCHROME, but there should be at most one
            /// option of each of the other types.
            /// </summary>
            public Type Type { get; private set; }

            /// <summary>
            /// Non-localized user-friendly string that represents this option.
            /// New CDDs should use custom_display_name_localized instead. It is required
            /// that either custom_display_name or custom_display_name_localized is set
            /// for options of type CUSTOM_COLOR and CUSTOM_MONOCHROME. Options of each
            /// of the other types will have their display name localized by the server.
            /// </summary>
            public string CustomDisplayName { get; private set; }

            /// <summary>
            /// Whether this option should be selected by default. Only one option
            /// should be set as default.
            /// </summary>
            public bool IsDefault { get; private set; } = false;

            /// <summary>
            /// Translations of custom display name of the option.
            /// If not empty, must contain an entry with locale == EN.
            /// </summary>
            public IList<LocalizedString> CustomDisplayNameLocalized { get; private set; }
        }

        public IList<Option> ColorOption { get; private set; }
    }

}
