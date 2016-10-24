using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Attributes
{
    class RequiredFor20Attribute : Attribute
    {
        public RequiredFor20Attribute()
        {

        }

        public RequiredFor20Attribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
