namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating whether to print in reverse.
    /// </summary>
    public class ReverseOrderTicketItem
    {
        //public ReverseOrderTicketItem(bool reverse_order)
        //{
        //    ReverseOrder = reverse_order;
        //}

        /// <summary>
        /// Whether to print in reverse (required).
        /// </summary>
        public bool ReverseOrder { get; set; }
    }

}
