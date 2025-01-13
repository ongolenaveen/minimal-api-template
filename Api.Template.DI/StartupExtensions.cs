using Api.Template.Services;
using Api.Template.Services.Interfaces;
using Api.Template.Shared;
using Api.Template.Shared.Interfaces;
using Api.Template.Sql.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Template.DI
{
    public static class StartupExtensions
    {
        public static void AddWebAppBindings(this IServiceCollection services, IConfiguration config)
        {
            SharedServicesStartup.AddSharedServices(services);
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDataProviderStartup, SqlDataProviderStartup>();

            var serviceProvider = services.BuildServiceProvider();
            var providers = serviceProvider.GetServices<IDataProviderStartup>();
            foreach (var provider in providers)
            {
                provider.AddDataProviders(services, config);
            }
        }
    }
}
