using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Share
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MembershipType
    {
        NONE,
        MEMBER,
        MANAGER
    }
}