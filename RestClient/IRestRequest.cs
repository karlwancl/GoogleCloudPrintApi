using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public interface IRestRequest
    {
        IReadOnlyDictionary<string, string> Headers { get; }

        IReadOnlyDictionary<string, string> Parameters { get; }
    }
}
