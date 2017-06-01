namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating whether to print in reverse.
    /// </summary>
    public class ReverseOrderTicketItem
    {
        /// <summary>
        /// Whether to print in reverse (required).
        /// </summary>
        public bool ReverseOrder { get; set; }
    }

}
