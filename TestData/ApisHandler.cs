using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace TestData
{
    public static class ApisHandler
    {
        public static string GetOpportunitiesApiConfiguration(string path, string storedProcedure)
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;

            var file = File.ReadAllText(Path.Combine(testDirectory, path, storedProcedure));

            var config = JObject.Parse(file);

            return string.Empty;
        } //"Apis\\environments.json"
    }
}