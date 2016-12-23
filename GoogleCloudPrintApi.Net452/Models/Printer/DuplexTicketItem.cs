namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating which duplexing option to use.
    /// </summary>
    public class DuplexTicketItem
    {
        public DuplexTicketItem(Duplex.Type type)
        {
            Type = type;
        }

        /// <summary>
        /// Type of duplexing (required).
        /// </summary>
        public Duplex.Type Type { get; private set; }
    }

}
