using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace GoogleCloudPrintApi.Helpers
{
    class UrlBuilder
    {
        public UrlBuilder(string baseAddress)
        {
            _baseAddress = baseAddress;
            _parameters = new Dictionary<string, string>();
        }

        private string _baseAddress;

        public string BaseAddress => _baseAddress;

        private Dictionary<string, string> _parameters;

        public Dictionary<string, string> Parameters => _parameters;

        public UrlBuilder Param(string key, string value)
        {
            _parameters.Add(key, value);
            return this;
        }

        public string Build()
        {
            var builder = new StringBuilder();
            builder.Append($"{_baseAddress.TrimEnd('/')}?");
            foreach (var kvp in _parameters)
            {
                builder.Append($"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}&");
            }
            return builder.ToString().TrimEnd('&').TrimEnd('?');
        }
    }
}
