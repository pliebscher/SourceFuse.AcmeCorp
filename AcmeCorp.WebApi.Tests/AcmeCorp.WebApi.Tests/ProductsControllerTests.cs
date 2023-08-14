using System.Collections.Generic;
using System.Net.Http;
using RestSharp;

namespace AcmeCorp.WebApi.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        private readonly string _apiKey = "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";
        private RestClient _restClient;

        [TestInitialize]
        public void Setup()
        {
            // Adjust for environment...
            // This should be in a config file that adjusted in the CI/CD pipeline...
            //string apiUrl = "http://localhost:49162/"; // Docker
            string apiUrl = "http://localhost:14627/"; // IIS Express

            _restClient = new RestClient(apiUrl);
            _restClient.AddDefaultHeader("XApiKey", _apiKey);

        }

        [TestMethod]
        public void GetAllProductsTest() 
        {

            RestRequest request = new RestRequest("api/Products", Method.Get);
            RestResponse response = _restClient.Execute(request);

            Assert.IsTrue(response.IsSuccessStatusCode);

        }

    }
}