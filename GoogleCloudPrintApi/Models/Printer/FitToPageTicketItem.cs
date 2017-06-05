namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Ticket item indicating what page-fitting algorithm to use.
    /// </summary>
    public class FitToPageTicketItem
    {
        /// <summary>
        /// Type of page fitting (required).
        /// </summary>
        public FitToPage.Type Type { get; set; }
    }
}