using GoogleCloudPrintApi.Models.Job;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Diff that can be applied to a PrintJobState message. Any omitted field will
    /// not be changed.
    /// Reference: https://developers.google.com/cloud-print/docs/cdd?hl=zh-TW#pjsdiff
    /// </summary>
    public class PrintJobStateDiff
    {
        /// <summary>
        /// New job state.
        /// </summary>
        public JobState State { get; set; }

        /// <summary>
        /// New number of pages printed.
        /// </summary>
        public int PagesPrinted { get; set; }
    }
}