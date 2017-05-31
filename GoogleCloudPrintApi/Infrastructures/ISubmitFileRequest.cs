using System;
using GoogleCloudPrintApi.Models.Application;

namespace GoogleCloudPrintApi.Infrastructures
{
    public interface ISubmitFileRequest: IRequest
    {
        ISubmitFile Content { get; set; }
    }
}
