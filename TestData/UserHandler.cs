using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public static class UserHandler
    {
        public static JObject GetUserData(Environments.Environments environment, string countryCode)
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;

            var file = File.ReadAllText(Path.Combine(testDirectory, $"Users\\{environment.ToString().ToUpper()}\\{countryCode.ToUpper()}.json"));

            var userData = JObject.Parse(file);

            return userData;
        }
    }
}