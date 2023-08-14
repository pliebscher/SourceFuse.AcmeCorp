using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net;

using AcmeCorp.Data.Context;
using AcmeCorp.WebApi.Middleware;
using AcmeCorp.WebApi;

namespace AcmeCorp.WebApi.Tests
{
    [TestClass]
    public class TestSetup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Task.Run(() => AcmeCorp.WebApi.Program.Main(new string[0]));
            //AcmeCorp.WebApi.Program.Main(new string[0]);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
