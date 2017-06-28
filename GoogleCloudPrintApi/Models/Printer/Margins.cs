using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Capability that defines the margins available on a device (including a custom one). Margins are measured in microns.
	/// </summary>
	public class Margins
    {
		/// <summary>
		/// Enumerates the set of predefined types of margins. Devices should use these
		/// types to semantically describe the margins option. This type will be used
		/// for UI purposes only.
		/// </summary>
		public enum TypeType
        {
            BORDERLESS,
            STANDARD,
            CUSTOM
        }

        public class OptionType
        {
			/// <summary>
			/// Type of margin option (required).
			/// </summary>
			/// <value>The type.</value>
			public TypeType Type { get; set; }

			/// <summary>
			/// Top margin of the page (required).
			/// </summary>
			/// <value>The top microns.</value>
			public int TopMicrons { get; set; }

			/// <summary>
			/// Right margin of the page (required).
			/// </summary>
			/// <value>The right microns.</value>
			public int RightMicrons { get; set; }

			/// <summary>
			/// Bottom margin of the page (required).
			/// </summary>
			/// <value>The bottom microns.</value>
			public int BottomMicrons { get; set; }

			/// <summary>
			/// Left margin of the page (required).
			/// </summary>
			/// <value>The left microns.</value>
			public int LeftMicrons { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this
            /// <see cref="T:GoogleCloudPrintApi.Models.Printer.Margins.Option"/> is default.
            /// </summary>
            /// <value><c>true</c> if is default; otherwise, <c>false</c>.</value>
            public bool IsDefault { get; set; } = false;
		}

        public IList<OptionType> Option { get; set; }
    }
}