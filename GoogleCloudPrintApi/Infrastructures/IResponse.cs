namespace GoogleCloudPrintApi.Infrastructures
{
    public interface IResponse<T> where T : IRequest
    {
        bool Success { get; }

        string Message { get; }

        string XsrfToken { get; }

        dynamic Request { get; }
    }
}