namespace GoogleCloudPrintApi.Infrastructures
{
    public class Response<T> : IResponse<T> where T : IRequest
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string XsrfToken { get; set; }

        public dynamic Request { get; set; }
    }
}