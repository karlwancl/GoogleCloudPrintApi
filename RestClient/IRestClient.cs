using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    interface IRestClient
    {
        string BaseAddress { get; }

        IRestResponse Get(IRestRequest request, string requestUri = null);

        Task<IRestResponse> GetAsync(IRestRequest request, string requestUri = null);

        IRestResponse Post(IRestRequest request, string requestUri = null);

        Task<IRestResponse> PostAsync(IRestRequest request, string requestUri = null);
    }
}
