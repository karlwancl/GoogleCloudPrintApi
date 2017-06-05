using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Section of a CDD that describes the capabilities and physical units of a cloud-connected printer.
    /// </summary>
    public class PrinterDescriptionSection
    {
        /// <summary>
        /// Content types (sometimes referred to as MIME types) that are supported by the printer.
        /// </summary>
        /// <value>The type of the supported content.</value>
        public IList<SupportedContentType> SupportedContentType { get; set; }

        /// <summary>
        /// Printing speeds that the printer can operate at.
        /// </summary>
        /// <value>The printing speed.</value>
        public PrintingSpeed PrintingSpeed { get; set; }

		/// <summary>
		/// PWG raster configuration of the printer.
		/// </summary>
		/// <value>The pwg raster config.</value>
		public PwgRasterConfig PwgRasterConfig { get; set; }

		/// <summary>
		/// Physical model of the printer's input trays.
		/// </summary>
		/// <value>The input tray unit.</value>
		public IList<InputTrayUnit> InputTrayUnit { get; set; }

		/// <summary>
		/// Physical model of the printer's output bins.
		/// </summary>
		/// <value>The output bin unit.</value>
		public IList<OutputBinUnit> OutputBinUnit { get; set; }

		/// <summary>
		/// Physical model of the printer's markers.
		/// </summary>
		/// <value>The marker.</value>
		public IList<Marker> Marker { get; set; }

		/// <summary>
		/// Physical model of the printer's covers.
		/// </summary>
		/// <value>The cover.</value>
		public IList<Cover> Cover { get; set; }

		/// <summary>
		/// Physical model of the printer's media paths.
		/// </summary>
		/// <value>The media path.</value>
		public IList<MediaPath> MediaPath { get; set; }

		/// <summary>
		/// Vendor-provided printer capabilities.
		/// </summary>
		/// <value>The vendor capability.</value>
		public IList<VendorCapability> VendorCapability { get; set; }

		/// <summary>
		/// Color printing capabilities of the printer.
		/// </summary>
		/// <value>The color.</value>
		public Color Color { get; set; }

		/// <summary>
		/// Duplexing capabilities of the printer.
		/// </summary>
		/// <value>The duplex.</value>
		public Duplex Duplex { get; set; }

		/// <summary>
		/// Page/paper orientation capabilities of the printer.
		/// </summary>
		/// <value>The page orientation.</value>
		public PageOrientation PageOrientation { get; set; }

		/// <summary>
		/// Multiple copy capability of the printer.
		/// </summary>
		/// <value>The copies.</value>
		public Copies Copies { get; set; }

		/// <summary>
		/// Page margins capability of the printer.
		/// </summary>
		/// <value>The margins.</value>
		public Margins Margins { get; set; }

		/// <summary>
		/// Printing quality or dots-per-inch (DPI) capabilities of the printer.
		/// </summary>
		/// <value>The dpi.</value>
		public Dpi Dpi { get; set; }

		/// <summary>
		/// Page fitting capabilities of the printer.
		/// </summary>
		/// <value>The fit to page.</value>
		public FitToPage FitToPage { get; set; }

		/// <summary>
		/// Page range selection capability of the printer.
		/// </summary>
		/// <value>The page range.</value>
		public PageRange PageRange { get; set; }

		/// <summary>
		/// Page or media size capabilities of the printer.
		/// </summary>
		/// <value>The size of the media.</value>
		public MediaSize MediaSize { get; set; }

		/// <summary>
		/// Paper collation capability of the printer.
		/// </summary>
		/// <value>The collate.</value>
		public Collate Collate { get; set; }

		/// <summary>
		/// Reverse order printing capability of the printer.
		/// </summary>
		/// <value>The reverse order.</value>
		public ReverseOrder ReverseOrder { get; set; }
    }
}