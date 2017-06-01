using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// Ticket item indicating what pages to use.
    /// </summary>
    public class PageRangeTicketItem
    {
        public IList<PageRange.Interval> Interval { get; set; }
    }

}
