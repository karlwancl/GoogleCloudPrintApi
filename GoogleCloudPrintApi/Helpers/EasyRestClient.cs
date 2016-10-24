using GoogleCloudPrintApi.Infrastructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Helpers
{
    class EasyRestClient
    {
        public EasyRestClient(string baseAddress)
        {
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _baseAddress = baseAddress;
        }

        string _baseAddress;

        Dictionary<string, string> _headers;

        Dictionary<string, string> _parameters;

        public EasyRestClient Header(string key, string value)
        {
            _headers.Add(key, value);
            return this;
        }

        public EasyRestClient Auth(string accessToken)
        {
            _headers.Add("Authorization", $"Bearer {accessToken}");
            return this;
        }

        public EasyRestClient Accept(string mimeType)
        {
            _headers.Add("Accept", mimeType);
            return this;
        }

        public EasyRestClient Param(string key, string value)
        {
            _parameters.Add(key, value);
            return this;
        }

        public EasyRestClient ParamIf(string key, string value, bool condition) => condition ? Param(key, value) : this;

        public EasyRestClient ParamIfNotNull(string key, IJsonSerializable serializable) => ParamIf(key, serializable.ToJson(), serializable != null);

        public EasyRestClient ParamIfNotNullOrEmpty(string key, string value) => ParamIf(key, value, !string.IsNullOrEmpty(value));

        public EasyRestClient ParamIff(string key, string trueValue, string falseValue, bool condition) => Param(key, condition ? trueValue : falseValue);

        public EasyRestClient ParamForEach(string key, IEnumerable<string> values)
        {
            if (values != null)
            {
                foreach (var value in values)
                {
                    _parameters.Add(key, value);
                }
            }
            return this;
        }

        public T Get<T>(string requestUri = "") => Execute<T>(requestUri, Method.Get);

        public string Get(string requestUri = "") => Execute(requestUri, Method.Get);

        public T Post<T>(string requestUri = "") => Execute<T>(requestUri, Method.Post);

        public string Post(string requestUri = "") => Execute(requestUri, Method.Post);

        public T Execute<T>(string requestUri = "", Method method = Method.Get)
        {
            string result = Execute(requestUri, method);
            return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }

        public string Execute(string requestUri = "", Method method = Method.Get) => GetContent(requestUri, method).ReadAsStringAsync().Result;

        public byte[] ExecuteBytes(string requestUri = "", Method method = Method.Get) => GetContent(requestUri, method).ReadAsByteArrayAsync().Result;

        private HttpContent GetContent(string requestUri = "", Method method = Method.Get)
        {
            using (var client = CreateHttpClient())
            {
                var content = new FormUrlEncodedContent(_parameters);
                var response = method == Method.Get ? client.GetAsync(requestUri).Result : client.PostAsync(requestUri, content).Result;
                using (response)
                {
                    response.EnsureSuccessStatusCode();
                    return response.Content;
                }
            }
        }

        public async Task<T> GetAsync<T>(string requestUri = "") => await ExecuteAsync<T>(requestUri, Method.Get);

        public async Task<string> GetAsync(string requestUri = "") => await ExecuteAsync(requestUri, Method.Get);

        public async Task<T> PostAsync<T>(string requestUri = "") => await ExecuteAsync<T>(requestUri, Method.Post);

        public async Task<string> PostAsync(string requestUri = "") => await ExecuteAsync(requestUri, Method.Post);
        
        public async Task<T> ExecuteAsync<T>(string requestUri = "", Method method = Method.Get)
        {
            string result = await ExecuteAsync(requestUri, method);
            return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }

        public async Task<string> ExecuteAsync(string requestUri = "", Method method = Method.Get) => await (await GetContentAsync(requestUri, method)).ReadAsStringAsync();

        public async Task<byte[]> ExecuteBytesAsync(string requestUri = "", Method method = Method.Get) => await (await GetContentAsync(requestUri, method)).ReadAsByteArrayAsync();

        private async Task<HttpContent> GetContentAsync(string requestUri = "", Method method = Method.Get)
        {
            using (var client = CreateHttpClient())
            {
                var content = new FormUrlEncodedContent(_parameters);
                var response = method == Method.Get ? await client.GetAsync(requestUri) : await client.PostAsync(requestUri, content);
                using (response)
                {
                    response.EnsureSuccessStatusCode();
                    return response.Content;
                }
            }
        }

        public async Task<T> PostMultipartAsync<T>(string requestUri = "")
        {
            using (var client = CreateHttpClient())
            {
                var content = new MultipartFormDataContent();
                foreach (var kvp in _parameters)
                {
                    content.Add(new StringContent(kvp.Value), kvp.Key);
                }
                using (var response = await client.PostAsync(requestUri, content))
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
                }
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders.Clear();

            var authHeader = _headers.LastOrDefault(kvp => kvp.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));
            if (!authHeader.Equals(default(KeyValuePair<string, string>)))
                client.DefaultRequestHeaders.Add(authHeader.Key, authHeader.Value);

            var acceptHeaders = _headers.Where(kvp => kvp.Key.Equals("Accept", StringComparison.OrdinalIgnoreCase));
            if (acceptHeaders != null)
            {
                string key = acceptHeaders.First().Key;
                string value = string.Join(",", acceptHeaders.Select(kvp => kvp.Value));
                client.DefaultRequestHeaders.Add(key, value);
            }

            foreach (var header in _headers)
            {
                bool isAuthHeader = header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase);
                bool isAcceptHeader = header.Key.Equals("Accept", StringComparison.OrdinalIgnoreCase);
                if (!isAuthHeader && !isAcceptHeader)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            return client;
        }
    }

    enum Method { Get, Post }
}
