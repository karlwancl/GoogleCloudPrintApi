namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating whether to collate pages.
    /// </summary>
    public class CollateTicketItem
    {
        public CollateTicketItem(bool collate)
        {
            Collate = collate;
        }

        /// <summary>
        /// Whether to print collated (required).
        /// </summary>
        public bool Collate { get; private set; }
    }

}
