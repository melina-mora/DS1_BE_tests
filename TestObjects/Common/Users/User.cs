using System.Net.Http;
using TestData.Environments;
using TestObjects.Common;
using TestObjects.Common.Requests;

namespace TestObjects.Common.Users
{
    public class User : Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public EnvironmentTypes EnvironmentType { get; set; }
        public string CountryCode { get; set; }
        public string LegalEntity { get; set; }

        public User(string baseUrl, string username, string password, EnvironmentTypes environmentType, string legalEntity)
        {
            Username = username;
            Password = password;
            EnvironmentType = environmentType;
            LegalEntity = legalEntity;

            Initialize(baseUrl);
            Login();
        }

        public HttpResponseMessage Login()
        {
            var sessionData = RequestSession(Username, Password, EnvironmentType);
            return sessionData;
        }
    }
}