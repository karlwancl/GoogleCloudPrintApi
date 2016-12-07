using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Models.Share
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EntryType
    {
        USER,
        GROUP,
        DOMAIN
    }
}
