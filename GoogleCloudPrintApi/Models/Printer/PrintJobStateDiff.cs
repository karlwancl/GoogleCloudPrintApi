using GoogleCloudPrintApi.Infrastructures;
using GoogleCloudPrintApi.Models.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
