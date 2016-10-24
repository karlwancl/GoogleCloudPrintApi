using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterResponse
    {
        public PrinterResponse(bool success, string xsrf_token, dynamic request, List<Printer> printers)
        {
            Success = success;
            XsrfToken = xsrf_token;
            Request = request;
            Printers = printers;
        }

        public bool Success { get; private set; }

        public string XsrfToken { get; private set; }

        [PartiallySupported("Parse json dynamically")]
        public dynamic Request { get; private set; }

        public List<Printer> Printers { get; private set; }
    }
}
