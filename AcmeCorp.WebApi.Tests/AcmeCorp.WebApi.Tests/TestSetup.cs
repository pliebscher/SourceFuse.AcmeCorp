using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeCorp.WebApi.Tests
{

    [TestClass]
    public class TestSetup
    {
        public static RestClient? RestClient { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            string _apiKey = "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";

            // Adjust for environment...
            // This should be in a config file that adjusted in the CI/CD pipeline...
            //string apiUrl = "http://localhost:49162/"; // Docker
            string apiUrl = "http://localhost:14627/"; // IIS Express

            RestClient = new RestClient(apiUrl);
            RestClient.AddDefaultHeader("XApiKey", _apiKey);

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
 
        }
    }

}
