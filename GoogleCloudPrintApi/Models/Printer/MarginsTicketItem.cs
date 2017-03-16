namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what margins to use (in microns).
    /// </summary>
    public class MarginsTicketItem
    {
        //public MarginsTicketItem(int top_microns, int right_microns, int bottom_microns, int left_microns)
        //{
        //    TopMicrons = top_microns;
        //    RightMicrons = right_microns;
        //    BottomMicrons = bottom_microns;
        //    LeftMicrons = left_microns;
        //}

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
