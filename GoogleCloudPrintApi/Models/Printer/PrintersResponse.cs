using GoogleCloudPrintApi.Infrastructures;
using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrintersResponse<T> : Response<T> where T : IRequest
    {
        public IList<Printer> Printers { get; set; }
    }
}