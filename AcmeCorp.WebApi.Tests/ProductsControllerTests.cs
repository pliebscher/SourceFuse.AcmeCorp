using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcmeCorp.WebApi.Tests
{
    /// <summary>
    /// Integration tests for the Orders API
    /// </summary>
    [TestClass]
    public class ProductsControllerTests
    {
        private readonly string _apiKey = "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp";
        private HttpClient _httpClient;

        [TestInitialize]
        public void Setup()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:14627/")
            };

            _httpClient.DefaultRequestHeaders.Add("XApiKey", _apiKey);
        }

        [TestMethod]
        public async void GetProductsTest()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Products");
            response.EnsureSuccessStatusCode();
        }

    }
}