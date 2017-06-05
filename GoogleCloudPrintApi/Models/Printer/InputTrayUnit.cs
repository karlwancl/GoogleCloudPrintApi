using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Physical model of a printer input tray.
	/// </summary>
	public class InputTrayUnit
    {
		[JsonConverter(typeof(StringEnumConverter))]
		public enum TypeType
        {
			CUSTOM = 0,
			INPUT_TRAY = 1,
			BYPASS_TRAY = 2,
			MANUAL_FEED_TRAY = 3,
			LCT = 4,  // Large capacity tray.
			ENVELOPE_TRAY = 5,
			ROLL = 6
        }

		/// <summary>
		/// Vendor-provided ID of the input tray (required).
		/// </summary>
		/// <value>The vendor identifier.</value>
		public string VendorId { get; set; }

		/// <summary>
		/// Type of input tray (required).
		/// </summary>
		/// <value>The type.</value>
		public TypeType Type { get; set; }

		/// <summary>
		/// Index of the input tray.
		/// </summary>
		/// <value>The index.</value>
		public long Index { get; set; }

		/// <summary>
		/// Non-localized custom display name of the input tray. New CDDs should use custom_display_name_localized instead.
		/// </summary>
		/// <value>The name of the custom display.</value>
		public string CustomDisplayName { get; set; }

		/// <summary>
		/// Translations of custom display name of the input tray.
		/// </summary>
		/// <value>The custom display name localized.</value>
		public IList<LocalizedString> CustomDisplayNameLocalized { get; set; } 
    }
}