using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class JobResponse<T> : Response<T> where T : IRequest
    {
        public Job.Job Job { get; set; }
    }
}