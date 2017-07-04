using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Capability that defines the 2D image quality levels available on a device.
	/// </summary>
	public class Dpi
    {
        public class OptionType
        {
			/// <summary>
			/// Horizontal DPI (required).
			/// </summary>
			/// <value>The horizontal API.</value>
			public int? HorizontalApi { get; set; }

			/// <summary>
			/// Vertical DPI (required).
			/// </summary>
			/// <value>The vertical API.</value>
			public int? VerticalApi { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this
            /// <see cref="T:GoogleCloudPrintApi.Models.Printer.Dpi.Option"/> is default.
            /// </summary>
            /// <value><c>true</c> if is default; otherwise, <c>false</c>.</value>
            public bool IsDefault { get; set; } = false;

			/// <summary>
			/// Non-localized custom display name to override the default display name
			/// which consists of "{$horizontal_dpi}x{$vertical_dpi} dpi".
			/// New CDDs should use custom_display_name_localized instead.
			/// </summary>
			/// <value>The name of the custom display.</value>
			public string CustomDisplayName { get; set; }

			/// <summary>
			/// Vendor-provided ID for the dpi option. Used to disambiguate dpi options
			/// that may have the same horizontal and vertical dpi but a different effect
			/// on the printer.
			/// </summary>
			/// <value>The vendor identifier.</value>
			public string VendorId { get; set; }

			/// <summary>
			/// Translations of custom display name of the option, if empty,
			/// "{$horizontal_dpi}x{$vertical_dpi} dpi" will be used. If not empty, must
			/// contain an entry with locale == EN.
			/// </summary>
			/// <value>The custom display name localized.</value>
			public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
        }

        public IList<OptionType> Option { get; set; }

        public int? MinHorizontalDpi { get; set; }

        public int? MaxHorizontalDpi { get; set; }

        public int? MinVerticalDpi { get; set; }

        public int? MaxVerticalDpi { get; set; }
    }
}