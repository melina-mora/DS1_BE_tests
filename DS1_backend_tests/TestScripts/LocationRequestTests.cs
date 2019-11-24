﻿using NUnit.Framework;
using TestData.Environments;
using TestObjects.Common.Users;

namespace TestScripts
{
    [TestFixture, Description("Some description for the fixture")]
    public class LocationRequestTests
    {
        [TestCase("MX", "crm")]
        public void LoginSuccessfully(string country, string userType)
        {
            var customer = new UserBuilder()
                .SetUserEnvironment(Environments.DEV, EnvironmentTypes.APIM)
                .SetCountry("MX")
                .SetUserType(userType)
                .Build();

            var response = customer.Login();
        }
    }
}