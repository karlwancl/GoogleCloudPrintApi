namespace GoogleCloudPrintApi.Models.Job
{
    public class PrintJobState
    {
        public string Version { get; set; }

        public JobState State { get; set; }

        public int PagesPrinted { get; set; }

        public int DeliveryAttempts { get; set; }
    }
}