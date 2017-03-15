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
        public PrintTicketSection(IList<VendorTicketItem> vendor_ticket_item = null, ColorTicketItem color = null, DuplexTicketItem duplex = null,
            PageOrientationTicketItem page_orientation = null, CopiesTicketItem copies = null, MarginsTicketItem margins = null, DpiTicketItem dpi = null,
            FitToPageTicketItem fit_to_page = null, PageRangeTicketItem page_range = null, MediaSizeTicketItem media_size = null, CollateTicketItem collate = null, ReverseOrderTicketItem reverse_order = null)
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
