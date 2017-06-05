using System;

namespace GoogleCloudPrintApi.Attributes
{
    /// <summary>
    /// Use it on a property that is used to determine if the call is a v2 web call or not
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class V2DeterminationKeyAttribute : System.Attribute
    {
        public bool IsByVersionNumber { get; }

        public V2DeterminationKeyAttribute(bool isByVersionNumber = false)
        {
            IsByVersionNumber = isByVersionNumber;
        }
    }
}