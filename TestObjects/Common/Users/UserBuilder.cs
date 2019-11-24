using TestData;
using TestData.Environments;

namespace TestObjects.Common.Users
{
    public class UserBuilder
    {

        public Environments Environment { get; set; }
        public EnvironmentTypes EnvironmentType { get; set; }

        private string Username { get; set; }
        private string Password { get; set; }
        private string CountryCode { get; set; }
        private string UserType { get; set; }
        private string LegalEntity { get; set; }

        public UserBuilder SetUserEnvironment(Environments environment, EnvironmentTypes environmentType)
        {
            Environment = environment;
            EnvironmentType = environmentType;

            return this;
        }

        public UserBuilder SetCredentials(string username, string password)
        {
            Username = username;
            Password = password;

            return this;
        }

        public UserBuilder SetCountry(string countryCode)
        {
            CountryCode = countryCode;
            return this;
        }

        public UserBuilder SetUserType(string userType)
        {
            UserType = userType;
            return this;
        }

        public UserBuilder SetLegalEntity(string legalEntity)
        {
            LegalEntity = legalEntity;
            return this;
        }

        public User Build()
        {
            var baseUrl = EnvironmentHandler.GetUrl(Environment, EnvironmentType);
            var userData = UserHandler.GetUserData(Environment, CountryCode);

            var user = new User(
                baseUrl, 
                userData[UserType.ToLower()]["user"].ToString(), 
                userData[UserType.ToLower()]["password"].ToString(), 
                EnvironmentType,
                userData[UserType.ToLower()]["legalEntity"]["legalEntityId"].ToString());

            return user;
        }
    }
}
