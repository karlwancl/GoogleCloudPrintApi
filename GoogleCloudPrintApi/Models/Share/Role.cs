using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Share
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        DEVICE,
        USER,
        MANAGER,
        OWNER
    }
}