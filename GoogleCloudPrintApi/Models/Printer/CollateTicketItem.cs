namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating whether to collate pages.
    /// </summary>
    public class CollateTicketItem
    {
        /// <summary>
        /// Whether to print collated (required).
        /// </summary>
        public bool Collate { get; set; }
    }

}
