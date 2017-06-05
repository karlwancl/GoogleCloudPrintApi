namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Ticket item indicating what image resolution to use.
    /// </summary>
    public class DpiTicketItem
    {
        /// <summary>
        /// Horizontal DPI to print at (required).
        /// </summary>
        public int HorizontalDpi { get; set; }

        /// <summary>
        /// Vertical DPI to print at (required).
        /// </summary>
        public int VerticalDpi { get; set; }

        /// <summary>
        /// Vendor-provided ID of the Dpi option. Needed to disambiguate Dpi options
        /// that have the same DPI values, but may have a different effect for the
        /// printer.
        /// </summary>
        public string VendorId { get; set; }
    }
}