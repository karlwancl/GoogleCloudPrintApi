namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Ticket item indicating how many copies to produce.
    /// </summary>
    public class CopiesTicketItem
    {
        /// <summary>
        /// Number of copies to print (required).
        /// </summary>
        public int Copies { get; set; }
    }
}