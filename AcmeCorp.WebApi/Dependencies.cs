using Microsoft.EntityFrameworkCore;
using AcmeCorp.Data.Context;
using AcmeCorp.Data.Repositories;
using AcmeCorp.Data.Repositories.Interfaces;

namespace AcmeCorp.WebApi
{
    public static class Dependencies
    {

        /// <summary>
        /// Register dependencies for Controller injections...
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services) 
        {

            services.AddScoped<AcmeCorpDataContext, AcmeCorpDataContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

    }
}
