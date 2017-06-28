using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Physical model of a printer marker.
	/// </summary>
	public class Marker
    {
		/// <summary>
		/// Enumeration of types of printer markers.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
        public enum TypeType
        {
            CUSTOM,
            TONER,
            INK,
            STAPLES
        }

		/// <summary>
		/// Message that describes the color of a marker.
		/// </summary>
		public class ColorType
        {
			/// <summary>
			/// Enumeration of color types of the printer marker.
			/// </summary>
			public enum TypeType
            {
                CUSTOM = 0,
                BLACK = 1,
                COLOR = 2,
                CYAN = 3,
                MAGENTA = 4,
                YELLOW = 5,
                LIGHT_CYAN = 6,
                LIGHT_MAGENTA = 7,
                GRAY = 8,
                LIGHT_GRAY = 9,
                PIGMENT_BLACK = 10,
                MATTE_BLACK = 11,
                PHOTO_CYAN = 12,
                PHOTO_MAGENTA = 13,
                PHOTO_YELLOW = 14,
                PHOTO_GRAY = 15,
                RED = 16,
                GREEN = 17,
                BLUE = 18
            }

			/// <summary>
			/// Required.
			/// </summary>
			/// <value>The type.</value>
			public TypeType Type { get; set; }

			/// <summary>
			/// Non-localized custom display name of the color.
			/// New CDDs should use custom_display_name_localized instead. It is required
			/// that either custom_display_name or custom_display_name_localized is set
			/// if the color's type is CUSTOM.
			/// </summary>
			/// <value>The name of the custom display.</value>
			public string CustomDisplayName { get; set; }

			/// <summary>
			/// Translations of custom display name of the color.
			/// If not empty, must contain an entry with locale == EN.
			/// </summary>
			/// <value>The custom display name localized.</value>
			public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
        }

		/// <summary>
		/// Vendor-provided ID of the marker (required).
		/// </summary>
		/// <value>The vendor identifier.</value>
		public string VendorId { get; set; }

		/// <summary>
		/// Type of marker (required).
		/// </summary>
		/// <value>The type.</value>
		public TypeType Type
        {
            get;
            set;
        }

		/// <summary>
		/// Color of the marker. Only needed if marker type is INK or TONER.
		/// </summary>
		/// <value>The color.</value>
		public ColorType Color
        {
            get;
            set;
        }

		/// <summary>
		/// Non-localized custom display name of the marker.
		/// New CDDs should use custom_display_name_localized instead. It is required
		/// that either custom_display_name or custom_display_name_localized is set
		/// if the marker's type is CUSTOM.
		/// </summary>
		/// <value>The name of the custom display.</value>
		public string CustomDisplayName { get; set; }

		/// <summary>
		/// Translations of custom display name of the marker.
		/// If not empty, must contain an entry with locale == EN.
		/// </summary>
		/// <value>The custom display name localized.</value>
		public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
    }
}