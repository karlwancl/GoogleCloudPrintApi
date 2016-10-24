using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterRequest
    {
        public string PrinterId { get; set; }

        public bool UseCdd { get; set; }

        public string ExtraFields { get; set; }
    }
}
