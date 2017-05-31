using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class ListRequest : IRequest
    {
        /// <summary>
        /// Identification of the proxy, as submitted while registering the printer. (required)
        /// </summary>
        [FormKey(isRequiredFor: VersionOption.All)]
        public string Proxy { get; set; }

        /// <summary>
        /// Comma-separated list of extra fields to include in the returned printer objects, see Extra Fields for Printers for more information. The queuedJobsCount extra field is useful here so that a software connector does not need to make a /fetch call for printers with zero queued jobs. Note that the /printer interface must be used in order to retrieve a printer's capabilities. (optional)
        /// </summary>
        [FormKey("extra_fields")]
        public string ExtraFields { get; set; }
    }
}
