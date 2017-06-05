using System;
using System.Linq;
using System.Reflection;

namespace GoogleCloudPrintApi.Infrastructures
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determine whether a type is simple (String, Decimal, DateTime, etc)
        /// or complex (i.e. custom class with public properties and methods).
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/2442534/how-to-test-if-type-is-primitive"/>
        internal static bool IsSimpleType(
            this Type type)
        {
            return
                type.GetTypeInfo().IsValueType ||
                type.GetTypeInfo().IsPrimitive ||
                new Type[] {
                typeof(String),
                typeof(Decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }
    }
}