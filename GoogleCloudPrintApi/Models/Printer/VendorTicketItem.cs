namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what value for a vendor-specific capability to use.
    /// </summary>
    public class VendorTicketItem
    {
        /// <summary>
        /// ID of vendor-specific capability that this ticket item refers to (required).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Value of ticket item (required).
        /// </summary>
        public string Value { get; set; }
    }

}
