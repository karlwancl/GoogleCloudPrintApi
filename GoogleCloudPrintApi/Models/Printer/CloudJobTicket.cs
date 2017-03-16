using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    /// <summary>
    /// Description of how a cloud job (e.g. print job, scan job) should be handled by the cloud device. Also known as CJT.
    /// </summary>
    public class CloudJobTicket
    {
        public CloudJobTicket(string version = "1.0", PrintTicketSection print = null, ScanTicketSection scan = null)
        {
            Version = version;
            Print = print;
            Scan = scan;
        }

        /// <summary>
        /// Version of the CJT in the form "X.Y" where changes to Y are backwards compatible, and changes to X are not (required).
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Section of CJT pertaining to cloud printer ticket items.
        /// </summary>
        public PrintTicketSection Print { get; private set; }

        /// <summary>
        /// Section of CJT pertaining to cloud scanner ticket items.
        /// </summary>
        public ScanTicketSection Scan { get; set; }
    }
}
