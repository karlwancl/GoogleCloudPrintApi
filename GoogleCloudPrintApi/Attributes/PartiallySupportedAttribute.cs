using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Attributes
{
    class PartiallySupportedAttribute : Attribute
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
