using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class TicketRequest
    {
        /// <summary>
        /// The job id of the cloud job ticket
        /// </summary>
        [Required]
        public string JobId { get; set; }

        /// <summary>
        /// Flag to control if use cloud job ticket or not
        /// </summary>
        public bool UseCjt { get; set; } = true;
    }
}
