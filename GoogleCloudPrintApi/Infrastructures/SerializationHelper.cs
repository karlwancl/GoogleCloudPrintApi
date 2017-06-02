using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleCloudPrintApi.Infrastructures
{
    internal static class SerializationHelper
    {
        internal static JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()  
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static JsonSerializerSettings DeserializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
    }
}
