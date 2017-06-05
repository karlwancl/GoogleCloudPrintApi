using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Configuration of how printer should receive PWG raster images.
	/// </summary>
	public class PwgRasterConfig
    {
        public class Resolution
        {
			/// <summary>
			/// Horizontal resolution in DPI.
			/// </summary>
			/// <value>The cross feed dir.</value>
			public int CrossFeedDir { get; set; }

			/// <summary>
			/// Vertical resolution in DPI.
			/// </summary>
			/// <value>The feed dir.</value>
			public int FeedDir { get; set; }
        }

		/// <summary>
		/// Resolutions (in DPI) of the pages that the printer supports in PWG-raster format.
		/// </summary>
		/// <value>The document resolution supported.</value>
		public IList<Resolution> DocumentResolutionSupported { get; set; }

		/// <summary>
		/// List of PWG-raster document types (in terms of color space and bits per color) supported by the printer.
		/// </summary>
		/// <value>The document type supported.</value>
		public IList<PwgDocumentTypeSupported> DocumentTypeSupported { get; set; }

        /// <summary>
        /// Same as PwgRasterDocumentSheetBack PWG-raster semantic model element.
        /// </summary>
        /// <value>The document sheet back.</value>
        public DocumentSheetBackType DocumentSheetBack { get; set; } = DocumentSheetBackType.ROTATED;

		/// <summary>
		/// Instructs GCP that the printer wants to print pages from the last to the first. In that case GCP will stream PWG-raster pages in that order.
		/// </summary>
		/// <value><c>true</c> if reverse order streaming; otherwise, <c>false</c>.</value>
		public bool ReverseOrderStreaming { get; set; }

		/// <summary>
		/// Instructs GCP that the printer prefers receiving pages rotated 180 degrees.
		/// </summary>
		/// <value><c>true</c> if rotate all pages; otherwise, <c>false</c>.</value>
		public bool RotateAllPages { get; set; }

		/// <summary>
		///  Describes which transformation needs to be applied to back pages in duplexing in order to have them printed properly.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
        public enum DocumentSheetBackType
        {
            // No special treatment for back pages (same as front page).
			NORMAL = 0,
			// Back pages are rotated 180 degrees if the document is portrait
			ROTATED = 1,
			// Back pages are rotated 180 degrees if the document is landscape
			MANUAL_TUMBLE = 2,
			// Page is flipped upside-down if portrait
			FLIPPED = 3
        }

		/// <summary>
		/// PWG-raster document types (in terms of color space and bits per color).
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public enum PwgDocumentTypeSupported
        {
			BLACK_1 = 1,
			SGRAY_1 = 2,
			ADOBE_RGB_8 = 3,
			BLACK_8 = 4,
			CMYK_8 = 5,
			DEVICE1_8 = 6,
			DEVICE2_8 = 7,
			DEVICE3_8 = 8,
			DEVICE4_8 = 9,
			DEVICE5_8 = 10,
			DEVICE6_8 = 11,
			DEVICE7_8 = 12,
			DEVICE8_8 = 13,
			DEVICE9_8 = 14,
			DEVICE10_8 = 15,
			DEVICE11_8 = 16,
			DEVICE12_8 = 17,
			DEVICE13_8 = 18,
			DEVICE14_8 = 19,
			DEVICE15_8 = 20,
			RGB_8 = 21,
			SGRAY_8 = 22,
			SRGB_8 = 23,
			ADOBE_RGB_16 = 24,
			BLACK_16 = 25,
			CMYK_16 = 26,
			DEVICE1_16 = 27,
			DEVICE2_16 = 28,
			DEVICE3_16 = 29,
			DEVICE4_16 = 30,
			DEVICE5_16 = 31,
			DEVICE6_16 = 32,
			DEVICE7_16 = 33,
			DEVICE8_16 = 34,
			DEVICE9_16 = 35,
			DEVICE10_16 = 36,
			DEVICE11_16 = 37,
			DEVICE12_16 = 38,
			DEVICE13_16 = 39,
			DEVICE14_16 = 40,
			DEVICE15_16 = 41,
			RGB_16 = 42,
			SGRAY_16 = 43,
			SRGB_16 = 44
        }

    }
}