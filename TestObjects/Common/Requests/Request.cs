using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TestData.Environments;

namespace TestObjects.Common.Requests
{
    public class Request
    {
        #region Properties

        public HttpClient Client { get; set; }
        private Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        #endregion Properties

        public void Initialize(string baseUrl)
        {
            var clientHandler = new HttpClientHandler //used to read the contents returned
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate //content can be gzip format or other
            };

            Client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(baseUrl)
            }; //crea un obj con un constructor vacio, y luego le asigna a la property elegida el valor deseado.
        }

        public void SetHeaders(Dictionary<string, string> headers)
        {
            Headers = headers;
        }

        public HttpResponseMessage Get(string url, Dictionary<string, string> parameters = null)
        {
            var requestBuilder = new RequestBuilder(url)
                .SetMethod(HttpMethod.Get)
                .AddHeaders(Headers);

            if (parameters != null)
            {
                requestBuilder.SetQueryParameters(parameters);
            }

            var request = requestBuilder.Build();

            return Client.SendAsync(request).Result;
        }

        public HttpResponseMessage Post(string url, object body)
        {
            var requestBuilder = new RequestBuilder(url)
               .SetMethod(HttpMethod.Post)
               .AddJsonBody(body)
               .AddHeaders(Headers);

            var request = requestBuilder.Build();

            return Client.SendAsync(request).Result;
        }

        public HttpResponseMessage RequestSession(string username, string password, EnvironmentTypes environmentType)
        {
            var jsonBody = new Dictionary<string, string>()
            {
                {"username", username},
                {"password", password},
                {"scope", "security"},
                {"grant_type","password"},
                {"client_id", "dd2ee55f-c93c-4c1b-b852-58c18cc7c277"}
            };

            var requestBuilder = new RequestBuilder("/v2/secm/oam/oauth2/token")
               .SetMethod(HttpMethod.Post)
               .AddFormBody(jsonBody)
               .AddHeaders(Headers);

            var request = requestBuilder.Build();
            var response = Client.SendAsync(request).Result;

            SetSessionToken(response, environmentType);

            return response;
        }

        public void SetSessionToken(HttpResponseMessage response, EnvironmentTypes environmentType)
        {
            var sessionData = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            var jwt = sessionData["jwt"].ToString();
            var accessToken = environmentType == EnvironmentTypes.APIM ? sessionData["oauth2"]["access_token"].ToString() : jwt;
            accessToken = $"Bearer {accessToken}";

            Headers = new Dictionary<string, string>()
            {
                {"X-IBM-Client-Id","8c46ee75-200c-46c5-aec0-2eae2c2fa924" },
                { "App-Code", "DCMWebTool_App"},
                {"Accept-Language", "en-US" },
                {"jwt", jwt },
                {"Authorization", accessToken }
            };
        }

        public HttpResponseMessage Patch(string url, object body)
        {
            var requestBuilder = new RequestBuilder(url)
                .SetMethod(new HttpMethod("PATCH"))
                .AddJsonBody(body)
                .AddHeaders(Headers);

            var request = requestBuilder.Build();

            return Client.SendAsync(request).Result;
        }

        public HttpResponseMessage Put(string url, object body)
        {
            var requestBuilder = new RequestBuilder(url)
                .SetMethod(HttpMethod.Put)
                .AddJsonBody(body)
                .AddHeaders(Headers);

            var request = requestBuilder.Build();

            return Client.SendAsync(request).Result;
        }

        public HttpResponseMessage Delete(string url)
        {
            var requestBuilder = new RequestBuilder(url)
                .SetMethod(HttpMethod.Delete)
                .AddHeaders(Headers);

            var request = requestBuilder.Build();

            return Client.SendAsync(request).Result;
        }
    }
}