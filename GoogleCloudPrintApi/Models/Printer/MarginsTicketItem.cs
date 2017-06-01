namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what margins to use (in microns).
    /// </summary>
    public class MarginsTicketItem
    {
        /// <summary>
        /// Top margin of the page (required).
        /// </summary>
        public int TopMicrons { get; set; }

        /// <summary>
        /// Top margin of the page (required).
        /// </summary>
        public int RightMicrons { get; set; }

        /// <summary>
        /// Top margin of the page (required).
        /// </summary>
        public int BottomMicrons { get; set; }

        /// <summary>
        /// Top margin of the page (required).
        /// </summary>
        public int LeftMicrons { get; set; }
    }

}
