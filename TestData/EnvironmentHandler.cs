using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public static class EnvironmentHandler
    {
        public static string GetUrl(Environments.Environments environment, Environments.EnvironmentTypes environmentType)
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;

            var file = File.ReadAllText(Path.Combine(testDirectory, "Environments\\environments.json"));
            //var config = JsonConvert.DeserializeObject(file);

            var config = JObject.Parse(file);

            var env = environment.ToString().ToLower();

            var envType = environmentType.ToString().ToLower();

            return config[env][envType].ToString();
        }
    }
}
