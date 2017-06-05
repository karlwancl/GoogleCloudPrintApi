using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Property that defines what speeds (in pages per minute) the printer can operate at.
	/// </summary>
	public class PrintingSpeed
    {
		/// <summary>
		/// Available speed of the printer.
		/// </summary>
		public class OptionType
        {
			/// <summary>
			/// Speed measured in pages per minute (required).
			/// </summary>
			/// <value>The speed ppm.</value>
			public float SpeedPpm { get; set; }

			/// <summary>
			/// Types of color settings that operate at this speed.
			/// </summary>
			/// <value>The type of the color.</value>
			public IList<Color.Type> ColorType { get; set; }

			/// <summary>
			/// Names of media sizes that operate at this speed.
			/// </summary>
			/// <value>The name of the media size.</value>
			public IList<MediaSize.Name> MediaSizeName { get; set; }
        }

		/// <summary>
		/// Speeds that the printer can operate at.
		/// </summary>
		/// <value>The option.</value>
		public IList<OptionType> Option { get; set; }
    }
}