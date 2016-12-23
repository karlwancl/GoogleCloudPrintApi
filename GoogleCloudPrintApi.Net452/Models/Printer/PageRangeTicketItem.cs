using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what pages to use.
    /// </summary>
    public class PageRangeTicketItem
    {
        public PageRangeTicketItem(IList<PageRange.Interval> interval)
        {
            Interval = interval;
        }

        public IList<PageRange.Interval> Interval { get; private set; }
    }

}
