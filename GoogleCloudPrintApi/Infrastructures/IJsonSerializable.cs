using Newtonsoft.Json;

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
            => JsonConvert.SerializeObject(serializable, SerializationHelper.SerializationSettings);
    }
}
