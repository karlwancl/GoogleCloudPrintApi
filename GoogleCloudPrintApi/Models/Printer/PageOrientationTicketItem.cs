namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Ticket item indicating which page orientation option to use.
    /// </summary>
    public class PageOrientationTicketItem
    {
        /// <summary>
        /// Page orientation type (required).
        /// </summary>
        public PageOrientation.Type Type { get; set; }
    }
}