using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Attributes;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Description of how a cloud job (e.g. print job, scan job) should be handled by the cloud device. Also known as CJT.
    /// Uses in SumbitRequest, uses get; set;
    /// </summary>
    public class CloudJobTicket
    {
        /// <summary>
        /// Version of the CJT in the form "X.Y" where changes to Y are backwards compatible, and changes to X are not (required).
        /// </summary>
        [FormKey]
        public string Version { get; set; } = "1.0";

        /// <summary>
        /// Section of CJT pertaining to cloud printer ticket items.
        /// </summary>
        [FormKey]
        public PrintTicketSection Print { get; set; }

        /// <summary>
        /// Section of CJT pertaining to cloud scanner ticket items. (Not implemented yet)
        /// </summary>
        [FormKey]
        public ScanTicketSection Scan { get; set; }
    }
}
