using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Capability that defines a default page-range selection on a device.
    /// </summary>
    public class PageRange
    {
        /// <summary>
        /// Interval of pages in the document to print.
        /// </summary>
        public class Interval
        {
            /// <summary>
            /// Beginning of the interval (inclusive) (required).
            /// </summary>
            public int? Start { get; set; }

            /// <summary>
            /// End of the interval (inclusive). If not set, then the interval will
            /// include all available pages after start.
            /// </summary>
            public int? End { get; set; }
        }

        public IList<Interval> Default { get; set; }
    }
}