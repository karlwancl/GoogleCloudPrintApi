using System;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Infrastructures
{
    public class ResponseBase<T> : IResponse<T> where T : IRequest
    {
        [JsonProperty]
        public bool Success { get; private set; }

		[JsonProperty]
		public string Message{ get; private set; }

		[JsonProperty("xsrf_token")]
		public string XsrfToken { get; private set; }

        [JsonProperty]
        public dynamic Request { get; private set; }
    }
}
