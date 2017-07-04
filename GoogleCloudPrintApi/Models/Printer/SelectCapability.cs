using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Selection-based device capability. Allows the user to select one or many of a set of options.
	/// </summary>
	public class SelectCapability
    {
		/// <summary>
		/// A user-selectable option of the vendor capability.
		/// </summary>
		public class OptionType
        {
			/// <summary>
			/// A single string that represents the value of this option. This value will be used in the VendorTicketItem.value field (required).
			/// </summary>
			/// <value>The value.</value>
			public string Value { get; set; }

			/// <summary>
			/// Non-localized user-friendly string to represent this option. 
            /// New CDDs should use display_name_localized instead. It is required that
			/// either display_name or display_name_localized is set.
			/// </summary>
			/// <value>The display name.</value>
			public string DisplayName { get; set; }

			/// <summary>
			/// Whether this option is the default option. Only one option should be marked as default.
			/// <see cref="T:GoogleCloudPrintApi.Models.Printer.SelectCapability.Option"/> is default.
			/// </summary>
			/// <value><c>true</c> if is default; otherwise, <c>false</c>.</value>
			public bool? IsDefault { get; set; }

			/// <summary>
			/// Translations of display name of the option. If not empty, must contain an entry with locale == EN.
			/// </summary>
			/// <value>The display name localized.</value>
			public IList<LocalizedString> DisplayNameLocalized { get; set; }
        }

		/// <summary>
		/// List of options available for this capability.
		/// </summary>
		/// <value>The option.</value>
		public IList<OptionType> Option { get; set; }
    }
}