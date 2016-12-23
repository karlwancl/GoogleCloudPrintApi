namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what image resolution to use.
    /// </summary>
    public class DpiTicketItem
    {
        public DpiTicketItem(int horizontal_dpi, int vertical_dpi, string vendor_id)
        {
            HorizontalDpi = horizontal_dpi;
            VerticalDpi = vertical_dpi;
            VendorId = vendor_id;
        }

        /// <summary>
        /// Horizontal DPI to print at (required).
        /// </summary>
        public int HorizontalDpi { get; private set; }

        /// <summary>
        /// Vertical DPI to print at (required).
        /// </summary>
        public int VerticalDpi { get; private set; }

        /// <summary>
        /// Vendor-provided ID of the Dpi option. Needed to disambiguate Dpi options
        /// that have the same DPI values, but may have a different effect for the
        /// printer.
        /// </summary>
        public string VendorId { get; private set; }
    }

}
