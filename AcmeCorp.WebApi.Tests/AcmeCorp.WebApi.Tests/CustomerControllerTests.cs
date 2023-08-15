using System.Collections.Generic;
using RestSharp;

using AcmeCorp.Data.Models;

namespace AcmeCorp.WebApi.Tests
{
    [TestClass]
    public class CustomerControllerTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void GetAllCustomersTest()
        {
            RestRequest request = new RestRequest("api/Customers", Method.Get);
            RestResponse response = TestSetup.RestClient.Execute(request);

            // We don't really care if there are any customers or not so just make sure the call was a success.
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void CreateCustomerTest() 
        {
            RestRequest request = new RestRequest("api/Customers", Method.Post);

            Customer customer = new Customer
            {
                Name = "SourceFusion, Inc."
            };

            request.AddJsonBody(customer);

            RestResponse response = TestSetup.RestClient.Execute(request);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        // All the other tests...
    }
}
