using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Exception
{
    public class GoogleCloudPrintException : System.Exception
    {
        public GoogleCloudPrintException(string message, string errorCode, dynamic request) : base(message)
        {
            ErrorCode = errorCode;
            Request = request;
        }

        public string ErrorCode { get; private set; }

        public dynamic Request { get; private set; }
    }
}
