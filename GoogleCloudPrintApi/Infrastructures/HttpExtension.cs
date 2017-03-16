using Flurl.Http;
using GoogleCloudPrintApi.Exception;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    static class HttpExtension
    {
        public static async Task<T> ReceiveJsonButThrowIfTagExists<T>(this Task<HttpResponseMessage> responseTask, string tag)
        {
            var responseString = await responseTask.ReceiveString().ConfigureAwait(false);
            if (responseString.Contains(tag))
            {
                dynamic error = JsonConvert.DeserializeObject(responseString);
                throw new GoogleCloudPrintException(error.message.ToString(), error.errorCode.ToString(), error.request);
            }
            return JsonConvert.DeserializeObject<T>(responseString, SerializationHelper.DeserializationSettings);
        }

        public static async Task<T> ReceiveJsonButThrowIfFails<T>(this Task<HttpResponseMessage> responseTask)
            => await ReceiveJsonButThrowIfTagExists<T>(responseTask, "\"success\": false").ConfigureAwait(false);
    }
}
