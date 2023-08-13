
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Extensions;

using System.Net;

using AcmeCorp.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using AcmeCorp.Data.Context;
using AcmeCorp.WebApi.Middleware;

namespace AcmeCorp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
     
            // Ignore cert errors for cross contaner development...
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            var builder = WebApplication.CreateBuilder(args);

            // Setup logging injection...
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Setup DbContext injection...
            builder.Services.AddDbContext<AcmeCorpDataContext>(options =>     
                options.UseSqlServer(builder.Configuration.GetConnectionString("AcmeCorpDataContext") ?? throw new InvalidOperationException("Connection string 'AcmeCorpDataContext' not found."))
            );

            
            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AcmeCorp Demo API", Version = "v12" });
                
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "ApiKey must appear in header - Demo Key: pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "XApiKey",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });

                var key = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    },
                    In = ParameterLocation.Header
                };

                var requirement = new OpenApiSecurityRequirement
                {
                    { key, new List<string>() }
                };

                c.AddSecurityRequirement(requirement);
            });

            // Register dependencies...
            Dependencies.Register(builder.Services);

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseAuthorization();
            app.UseMiddleware<ApiKeyMiddleware>();

            app.MapControllers();
            

            app.Run();
        }
    }



}