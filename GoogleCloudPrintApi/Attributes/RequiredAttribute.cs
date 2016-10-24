using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Attributes
{
    class RequiredAttribute : Attribute
    {
        public RequiredAttribute()
        {

        }

        public RequiredAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
