namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating which page orientation option to use.
    /// </summary>
    public class PageOrientationTicketItem
    {
        public PageOrientationTicketItem(PageOrientation.Type type)
        {
            Type = type;
        }

        /// <summary>
        /// Page orientation type (required).
        /// </summary>
        public PageOrientation.Type Type { get; private set; }
    }

}
