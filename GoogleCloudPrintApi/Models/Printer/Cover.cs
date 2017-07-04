using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Physical model of a printer cover.
	/// </summary>
	public class Cover
    {
		/// <summary>
		/// Enumeration of cover types.
		/// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public enum TypeType
        {
            CUSTOM,
            DOOR,
            COVER
        }

		/// <summary>
		/// Vendor-provided ID of the cover (required).
		/// </summary>
		/// <value>The vendor identifier.</value>
		public string VendorId { get; set; }

		/// <summary>
		/// Type of the cover (required).
		/// </summary>
		/// <value>The type.</value>
		public TypeType? Type { get; set; }

		/// <summary>
		/// Index of the cover.
		/// </summary>
		/// <value>The index.</value>
		public long? Index { get; set; }

		/// <summary>
		/// Non-localized custom display name of the cover.
		/// New CDDs should use custom_display_name_localized instead. It is required
		/// that either custom_display_name or custom_display_name_localized is set
		/// if the cover's type is CUSTOM.
		/// </summary>
		/// <value>The name of the custom display.</value>
		public string CustomDisplayName { get; set; }

		/// <summary>
		/// Translations of custom display name of the cover.
		/// If not empty, must contain an entry with locale == EN.
		/// </summary>
		/// <value>The custom display name localized.</value>
		public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
    }
}