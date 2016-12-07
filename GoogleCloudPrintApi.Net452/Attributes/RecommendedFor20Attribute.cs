using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Attributes
{
    class RecommendedFor20Attribute : Attribute
    {
        public RecommendedFor20Attribute()
        {

        }

        public RecommendedFor20Attribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
