using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Attributes;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Section of a CJT which describes how a print job should be handled by a cloud-connected printer.
    /// </summary>
    public class PrintTicketSection
    {
        [FormKey("vendor_ticket_item")]
        public IList<VendorTicketItem> VendorTicketItem { get; set; }

        [FormKey]
        public ColorTicketItem Color
        { get; set; }

        [FormKey]
        public DuplexTicketItem Duplex { get; set; }

        [FormKey("page_orientation")]
        public PageOrientationTicketItem PageOrientation { get; set; }

        [FormKey]
        public CopiesTicketItem Copies { get; set; }

        [FormKey]
        public MarginsTicketItem Margins { get; set; }

        [FormKey]
        public DpiTicketItem Dpi { get; set; }

        [FormKey("fit_to_page")]
        public FitToPageTicketItem FitToPage { get; set; }

        [FormKey("page_range")]
        public PageRangeTicketItem PageRange { get; set; }

        [FormKey("media_size")]
        public MediaSizeTicketItem MediaSize { get; set; }

        [FormKey]
        public CollateTicketItem Collate { get; set; }

        [FormKey("reverse_order")]
        public ReverseOrderTicketItem ReverseOrder { get; set; }
    }
}
