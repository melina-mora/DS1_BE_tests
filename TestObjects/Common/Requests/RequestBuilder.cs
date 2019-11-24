using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestObjects.Common.Requests
{
    /// <summary>
    /// Builds the request with the set configuration.
    /// </summary>
    class RequestBuilder
    {
        #region Properties
        private HttpMethod Method { get; set; } = HttpMethod.Get; //set GET enum value as default
        private Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>(); //set empty dict as default
        private Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>(); //set empty dict as default
        private HttpContent Content { get; set; }
        public string Url { get; set; }
        #endregion

        public RequestBuilder(string url)
        {
            Url = url;
        }

        public RequestBuilder SetMethod(HttpMethod method)
        {
            Method = method;
            return this;
        }

        public RequestBuilder AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                AddHeader(header.Key, header.Value);
            }
            return this;
        }

        public RequestBuilder AddHeader(string key, string value)
        {
            Headers[key] = value;
            return this;
        }

        public RequestBuilder SetQueryParameters(Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                Parameters[parameter.Key] = parameter.Value;
            }

            return this;
        }

        public RequestBuilder AddFormBody(Dictionary<string, string> form)
        {
            Content = new FormUrlEncodedContent(form);

            return this;
        }

        public RequestBuilder AddJsonBody(object body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);
            Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            return this;
        }

        public HttpRequestMessage Build()
        {
            if (Parameters.Count != 0)
            {
                UrlBuilder();
            }

            var request = new HttpRequestMessage(Method, Url);

            foreach (var header in Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            } //Set headers from prop

            if (Method != HttpMethod.Get && Content != null)
            {
                request.Content = Content;
            } //Set body from prop


            return request;

        }

        private RequestBuilder UrlBuilder()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var parameter in Parameters)
            {
                query[parameter.Key] = parameter.Value;
            }

            Url +=  "?" + query.ToString();

            return this;
        }
    }
}
