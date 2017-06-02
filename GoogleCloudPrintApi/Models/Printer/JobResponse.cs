using GoogleCloudPrintApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GoogleCloudPrintApi.Infrastructures;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class JobResponse<T>: Response<T> where T: IRequest
    {
        public Job.Job Job { get; set; }
    }
}
