using GoogleCloudPrintApi.Attributes;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Section of a CJT which describes how a print job should be handled by a cloud-connected printer.
    /// </summary>
    public class PrintTicketSection
    {
        [Form("vendor_ticket_item")]
        public IList<VendorTicketItem> VendorTicketItem { get; set; }

        public ColorTicketItem Color
        { get; set; }

        public DuplexTicketItem Duplex { get; set; }

        [Form("page_orientation")]
        public PageOrientationTicketItem PageOrientation { get; set; }

        public CopiesTicketItem Copies { get; set; }

        public MarginsTicketItem Margins { get; set; }

        public DpiTicketItem Dpi { get; set; }

        [Form("fit_to_page")]
        public FitToPageTicketItem FitToPage { get; set; }

        [Form("page_range")]
        public PageRangeTicketItem PageRange { get; set; }

        [Form("media_size")]
        public MediaSizeTicketItem MediaSize { get; set; }

        public CollateTicketItem Collate { get; set; }

        [Form("reverse_order")]
        public ReverseOrderTicketItem ReverseOrder { get; set; }
    }
}