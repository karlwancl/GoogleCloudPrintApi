using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    /// <summary>
    /// Marker interface for object serialization, properties of the serializable should add JsonPropertyAttribute
    /// </summary>
    public interface IJsonSerializable
    {
        // Intentionally blank
    }

    public static class JsonSerializableExtension
    {
        public static string ToJson(this IJsonSerializable serializable)
        {
            return JsonConvert.SerializeObject(serializable, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
