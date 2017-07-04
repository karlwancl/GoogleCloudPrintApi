using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Physical model of a printer output bin.
	/// </summary>
	public class OutputBinUnit
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeType
        {
            CUSTOM = 0,
            OUTPUT_BIN = 1,
            MAILBOX = 2,
            STACKER = 3
        }

		/// <summary>
		/// Vendor-provided ID of the output bin (required).
		/// </summary>
		/// <value>The vendor identifier.</value>
		public string VendorId { get; set; }

		/// <summary>
		/// Type of output bin (required).
		/// </summary>
		/// <value>The type.</value>
		public TypeType? Type { get; set; }

		/// <summary>
		/// Non-localized custom display name of the output bin.
		/// New CDDs should use custom_display_name_localized instead. It is required
		/// that either custom_display_name or custom_display_name_localized is set if
		/// the bin's type is CUSTOM.
		/// </summary>
		/// <value>The name of the custom display.</value>
		public string CustomDisplayName { get; set; }

		/// <summary>
		/// Translations of custom display name of the output bin.
		/// If not empty, must contain an entry with locale == EN.
		/// </summary>
		/// <value>The custom display name localized.</value>
		public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
    }
}