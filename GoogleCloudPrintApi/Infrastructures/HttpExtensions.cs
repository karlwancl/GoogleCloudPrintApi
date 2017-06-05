using Flurl.Http;
using GoogleCloudPrintApi.Attributes;
using GoogleCloudPrintApi.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    internal static class HttpExtensions
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

        public static async Task<HttpResponseMessage> PostRequestAsync(this IFlurlClient client, IRequest request, CancellationToken token = default(CancellationToken), bool isMultipart = false)
        {
            // Get all form keys from request
            var keys = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                  .Where(prop => prop.GetCustomAttribute<FormIgnoreAttribute>() == null);

            // Get determination key for determine if the web call is a v2 call or not
            var v2DetKey = keys.SingleOrDefault(prop => prop.GetCustomAttribute<V2DeterminationKeyAttribute>() != null);
            bool isV2 = v2DetKey != null && v2DetKey.GetValue(request) != null;
            if (isV2 && v2DetKey.GetCustomAttribute<V2DeterminationKeyAttribute>().IsByVersionNumber)
                isV2 &= v2DetKey.GetValue(request).ToString() == "2.0";

            // Get keys to process
            var keysToProcess = keys.Except(keys.Where(k => k.GetCustomAttribute<FormAttribute>()?.IsFor.Equals(isV2 ? VersionOption.V1 : VersionOption.V2) ?? false));

            // Check null for required keys
            foreach (var option in new List<VersionOption> { isV2 ? VersionOption.V2 : VersionOption.V1, VersionOption.All })
            {
                var keysToValidate = keysToProcess.Where(k => k.GetCustomAttribute<FormAttribute>()?.IsFor.Equals(option) ?? false);
                var invalidKeys = keysToValidate.Where(k => (k.GetCustomAttribute<FormAttribute>()?.IsRequiredFor.HasFlag(option) ?? false) && k.GetValue(request) == null);
                if (invalidKeys.Any())
                    throw new KeyRequiredException(invalidKeys.Select(k => k.Name).ToArray());
            }

            Func<PropertyInfo, string> keyName = prop => prop.GetCustomAttribute<FormAttribute>()?.Name ?? prop.Name.ToLower();

            // Process keys to form
            var form = new Dictionary<string, string>();
            keysToProcess.Where(ok => ok.GetValue(request) != null)
                 .ToList()
                 .ForEach(ok =>
            {
                if (ok.GetValue(request) is IEnumerable<string> list)
                    foreach (var item in list)
                        form.Add(keyName(ok), item);
                else
                {
                    var objValue = ok.GetValue(request);
                    if (!(objValue is bool && ok.GetCustomAttribute<FormAttribute>().AddKeyOnlyIfBoolTrue && !(bool)objValue))
                        form.Add(keyName(ok), ok.PropertyType.IsSimpleType() ?
                                 objValue.ToString() : JsonConvert.SerializeObject(ok.GetValue(request), SerializationHelper.SerializationSettings));
                }
            });

            return isMultipart ? await client.PostMultipartAsync(mp => mp.AddStringParts(form)) : await client.PostUrlEncodedAsync(form, token);
        }
    }
}