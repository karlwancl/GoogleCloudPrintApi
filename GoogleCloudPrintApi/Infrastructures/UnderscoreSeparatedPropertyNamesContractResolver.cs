using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

namespace GoogleCloudPrintApi.Infrastructures
{
    internal class UnderscoreSeparatedPropertyNamesContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Create json property according to the .NET property
        /// </summary>
        /// <param name="member">.NET object property</param>
        /// <param name="memberSerialization">Serialization option</param>
        /// <returns>Json property</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            // Translate only if JsonProperty is not specified
            if (property.PropertyName == member.Name)
            {
                string memberName = member.Name;
                memberName = memberName.Where(c => char.IsUpper(c)).Aggregate(memberName, (mn, c) => mn.Replace($"{c}", $"_{c}".ToLower()).TrimStart('_'));
                property.PropertyName = memberName;
            }
            return property;
        }

        /// <summary>
        /// Returns only properties for serialization/deserialization
        /// </summary>
        /// <param name="objectType">Class to serialize/deserialize</param>
        /// <returns>Properties</returns>
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var props = objectType.GetProperties(bindingFlags).Cast<MemberInfo>();
            return props.ToList();
        }
    }
}
