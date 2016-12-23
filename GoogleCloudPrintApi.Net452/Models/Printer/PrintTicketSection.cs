using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Section of a CJT which describes how a print job should be handled by a cloud-connected printer.
    /// </summary>
    public class PrintTicketSection
    {
        public PrintTicketSection(IList<VendorTicketItem> vendor_ticket_item, ColorTicketItem color, DuplexTicketItem duplex,
            PageOrientationTicketItem page_orientation, CopiesTicketItem copies, MarginsTicketItem margins, DpiTicketItem dpi,
            FitToPageTicketItem fit_to_page, PageRangeTicketItem page_range, MediaSizeTicketItem media_size, CollateTicketItem collate, ReverseOrderTicketItem reverse_order)
        {
            VendorTicketItem = vendor_ticket_item;
            Color = color;
            Duplex = duplex;
            PageOrientation = page_orientation;
            Copies = copies;
            Margins = margins;
            Dpi = dpi;
            FitToPage = fit_to_page;
            PageRange = page_range;
            MediaSize = media_size;
            Collate = collate;
            ReverseOrder = reverse_order;
        }

        public IList<VendorTicketItem> VendorTicketItem { get; private set; }

        public ColorTicketItem Color { get; private set; }

        public DuplexTicketItem Duplex { get; private set; }

        public PageOrientationTicketItem PageOrientation { get; private set; }

        public CopiesTicketItem Copies { get; private set; }

        public MarginsTicketItem Margins { get; private set; }

        public DpiTicketItem Dpi { get; private set; }

        public FitToPageTicketItem FitToPage { get; private set; }

        public PageRangeTicketItem PageRange { get; private set; }

        public MediaSizeTicketItem MediaSize { get; private set; }

        public CollateTicketItem Collate { get; private set; }

        public ReverseOrderTicketItem ReverseOrder { get; private set; }
    }
}
