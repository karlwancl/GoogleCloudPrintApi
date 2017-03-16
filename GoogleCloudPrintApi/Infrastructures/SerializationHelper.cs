using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Infrastructures
{
    internal static class SerializationHelper
    {
        internal static JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new UnderscoreSeparatedPropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static JsonSerializerSettings DeserializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new UnderscoreSeparatedPropertyNamesContractResolver(),
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
    }
}
