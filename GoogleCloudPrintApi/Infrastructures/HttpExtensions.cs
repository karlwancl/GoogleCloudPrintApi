using Flurl.Http;
using GoogleCloudPrintApi.Exception;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using GoogleCloudPrintApi.Attributes;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Collections;
using GoogleCloudPrintApi.Models.Application;
using Flurl.Http.Content;
using System.IO;

namespace GoogleCloudPrintApi.Infrastructures
{
    static class HttpExtensions
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
                                  .Where(prop => prop.GetCustomAttribute<FormKeyAttribute>() != null);

            // Get determination key for determine if the web call is a v2 call or not
            var v2DetKey = keys.SingleOrDefault(prop => prop.GetCustomAttribute<V2DeterminationKeyAttribute>() != null);
            bool isV2 = v2DetKey != null && v2DetKey.GetValue(request) != null;
            if (isV2 && v2DetKey.GetCustomAttribute<V2DeterminationKeyAttribute>().IsByVersionNumber)
                isV2 &= v2DetKey.GetValue(request).ToString() == "2.0";

            Func<PropertyInfo, string> keyName = prop => prop.GetCustomAttribute<FormKeyAttribute>()?.Name ?? prop.Name.ToLower();

            var optionsToProcess = new List<VersionOption>
            {
                isV2 ? VersionOption.V2 : VersionOption.V1,
                VersionOption.All
            };

            var form = new Dictionary<string, string>();
            foreach (var option in optionsToProcess)
            {
                var oKeys = keys.Where(k => k.GetCustomAttribute<FormKeyAttribute>().IsFor.Equals(option));

                // Check null for required keys
                var invalidOKeys = oKeys.Where(ok => ok.GetCustomAttribute<FormKeyAttribute>().IsRequiredFor.HasFlag(option) && ok.GetValue(request) == null);
                if (invalidOKeys.Any())
                    throw new KeyRequiredException(invalidOKeys.Select(k => k.Name).ToArray());

                oKeys.Where(ok => ok.GetValue(request) != null)
                     .ToList()
                     .ForEach(ok =>
                {
                    if (ok.GetValue(request) is IEnumerable<string> list)
                        foreach (var item in list)
                            form.Add(keyName(ok), item);
                    else
                    {
                        var objValue = ok.GetValue(request);
                        if (!(objValue is bool && ok.GetCustomAttribute<FormKeyAttribute>().AddKeyOnlyIfBoolTrue && !(bool)objValue))
                            form.Add(keyName(ok), ok.PropertyType.IsSimpleType() ?
                                     objValue.ToString() : JsonConvert.SerializeObject(ok.GetValue(request), SerializationHelper.SerializationSettings));
                    }
                });
            }

            return isMultipart ? await client.PostMultipartAsync(mp => mp.AddStringParts(form)) : await client.PostUrlEncodedAsync(form, token);
        }
    }
}
