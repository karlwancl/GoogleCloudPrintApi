namespace GoogleCloudPrintApi.Exception
{
    public class GoogleCloudPrintException : System.Exception
    {
        public GoogleCloudPrintException(string message, string errorCode = null, dynamic request = null) : base(message)
        {
            ErrorCode = errorCode;
            Request = request;
        }

        public string ErrorCode { get; private set; }

        public dynamic Request { get; private set; }
    }
}