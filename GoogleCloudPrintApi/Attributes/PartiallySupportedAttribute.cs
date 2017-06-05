using System;

namespace GoogleCloudPrintApi.Attributes
{
    internal class PartiallySupportedAttribute : Attribute
    {
        public PartiallySupportedAttribute()
        {
        }

        public PartiallySupportedAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}