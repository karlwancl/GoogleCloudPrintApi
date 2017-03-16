using System;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleCloudPrintApi
{
	public class UnderscoreSeparatedPropertyNamesContractResolver:DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			var property = base.CreateProperty(member, memberSerialization);

			var result = new StringBuilder();

			for (var i = 0; i < member.Name.Length; i++)
			{
				if (char.IsUpper(member.Name[i]))
				{
					if (result.Length != 0 && !char.IsUpper(member.Name[i -1]))
					{
						result.Append('_');
					}

					result.Append(char.ToLower(member.Name[i]));
				}
				else
				{
					result.Append(member.Name[i]);
				}
			}

			property.PropertyName = result.ToString();
			return property;
		}
	}
}