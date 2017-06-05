using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Capability that defines a default page-range selection on a device.
    /// </summary>
    public class PageRange
    {
        public PageRange(IList<Interval> @default)
        {
            Default = @default;
        }

        /// <summary>
        /// Interval of pages in the document to print.
        /// </summary>
        public class Interval
        {
            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }

            /// <summary>
            /// Beginning of the interval (inclusive) (required).
            /// </summary>
            public int Start { get; private set; }

            /// <summary>
            /// End of the interval (inclusive). If not set, then the interval will
            /// include all available pages after start.
            /// </summary>
            public int End { get; private set; }
        }

        public IList<Interval> Default { get; private set; }
    }
}