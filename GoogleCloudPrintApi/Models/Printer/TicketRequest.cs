using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class TicketRequest: IRequest
    {
        /// <summary>
        /// The job id of the cloud job ticket
        /// </summary>
        [FormKey(isFor: VersionOption.V2, isRequiredFor: VersionOption.All)]
        public string JobId { get; set; }

        /// <summary>
        /// Flag to control if use cloud job ticket or not
        /// </summary>
        [FormKey("use_cjt", VersionOption.V2)]
        public bool UseCjt { get; set; } = true;
    }
}
