using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
