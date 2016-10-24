using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Attributes
{
    class RequiredForXpsAttribute : Attribute
    {
        public RequiredForXpsAttribute()
        {

        }

        public RequiredForXpsAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
