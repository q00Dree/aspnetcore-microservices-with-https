using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.SecondService.HttpApiConnector;
using System;

namespace Sample.Gateway.Providers
{
    public static class ConnectorsProviderExtension
    {
        public static void AddConnectors(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ISecondServiceHttpApiConnector>(s => new SecondServiceHttpApiConnector(
                  new System.Net.Http.HttpClient()
                  {
                      BaseAddress = configuration.GetValue<Uri>("SecondServiceBaseUri")
                  }
            ));
        }
    }
}
