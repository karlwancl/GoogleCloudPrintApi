namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Ticket item indicating which color option to use.
    /// </summary>
    public class ColorTicketItem
    {
        /// <summary>
        /// Vendor ID of the color (required if the type is CUSTOM_COLOR or CUSTOM_MONOCHROME).
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// Type of the color (required).
        /// </summary>
        public Color.Type Type { get; set; }
    }
}