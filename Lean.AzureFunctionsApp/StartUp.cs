using Flurl.Http;
using Flurl.Http.Configuration;
using Lean.AzureFunctionsApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AutoMapper;

[assembly: FunctionsStartup(typeof(StartUp))]
namespace Lean.AzureFunctionsApp
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureFlurlHttpClient();
            ConfigureServices(builder);
            RegisterMediatR(builder);
            RegisterMappingProfile(builder);
        }

        private void ConfigureServices(IFunctionsHostBuilder builder)
        {

        }

        private void ConfigureFlurlHttpClient()
        {
            FlurlHttp.Configure(settings =>
            {
                var contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = contractResolver
                };

                settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
            });
        }

        private void RegisterMediatR(IFunctionsHostBuilder builder)
        {
            // TODO: Register Assembly
            //builder.Services.AddMediatR(typeof );
        }

        private void RegisterMappingProfile(IFunctionsHostBuilder builder)
        {
            // TODO: Register Assembly
            //builder.Services.AddAutoMapper(typeof );
        }
    }
}
