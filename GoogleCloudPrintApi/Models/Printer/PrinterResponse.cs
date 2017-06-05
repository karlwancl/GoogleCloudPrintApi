using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterResponse<T> : Response<T> where T : IRequest
    {
        public Printer Printer { get; set; }
    }
}