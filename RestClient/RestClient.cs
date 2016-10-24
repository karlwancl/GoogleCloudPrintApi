using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class RestClient : IRestClient
    {
        public RestClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        string _baseAddress;

        public string BaseAddress => _baseAddress;

        public IRestResponse Get(IRestRequest request, string requestUri = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> GetAsync(IRestRequest request, string requestUri = null)
        {
            throw new NotImplementedException();
        }

        public IRestResponse Post(IRestRequest request, string requestUri = null)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> PostAsync(IRestRequest request, string requestUri = null)
        {
            throw new NotImplementedException();
        }
    }
}
