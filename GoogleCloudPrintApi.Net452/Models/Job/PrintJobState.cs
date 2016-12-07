using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Job
{
    public class PrintJobState
    {
        public PrintJobState(string version, JobState state, int pages_printed, int delivery_attempts)
        {
            Version = version;
            State = state;
            PagesPrinted = pages_printed;
            DeliveryAttempts = delivery_attempts;
        }

        public string Version { get; private set; }

        public JobState State { get; private set; }

        public int PagesPrinted { get; private set; }

        public int DeliveryAttempts { get; private set; }
    }
}
