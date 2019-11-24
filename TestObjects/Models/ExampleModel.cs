using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObjects.Models
{
    public class ExampleModel //deprecated, use as example for building other models
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; } = "security";
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "password";
        [JsonProperty("client_id")]
        public string ClientId { get; set; } = "dd2ee55f-c93c-4c1b-b852-58c18cc7c277";

        public ExampleModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
