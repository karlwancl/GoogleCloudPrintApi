using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterRequest
    {
        [Required]
        public string PrinterId { get; set; }

        public string Client { get; set; }

        public string ExtraFields { get; set; }

        [Obsolete("Include use_cdd=false to receive printer capabilities as provided by the printer instead of in CDD format.")]
        public bool UseCdd { get; set; }

        [Obsolete("please use extra_fields instead")]
        public bool PrinterConnectionStatus { get; set; }
    }
}
