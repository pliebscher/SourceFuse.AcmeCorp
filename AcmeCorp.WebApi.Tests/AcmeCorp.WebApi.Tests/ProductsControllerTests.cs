using System.Collections.Generic;
using System.Net.Http;
using RestSharp;

namespace AcmeCorp.WebApi.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void GetAllProductsTest() 
        {

            RestRequest request = new RestRequest("api/Products", Method.Get);
            RestResponse response = TestSetup.RestClient.Execute(request);

            // We don't really care if there are any products or not so just make sure the call was a success.
            Assert.IsTrue(response.IsSuccessStatusCode);

        }

    }
}