using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public static class AccountModule
    {
        public static IServiceCollection AddAccountModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Services to the container
            //services
            //    .AddApplicationServices()
            //    .AddInfrastructureServices(configuration)
            //    .AddApiServices(configuration);

            return services;
        }

        public static IApplicationBuilder UseAccountModule(this IApplicationBuilder app)
        {
            // Add Services to the container
            //app
            //    .UseApplicationServices()
            //    .AUseInfrastructureServices()
            //    .UseApiServices();

            return app;
        }
    }
}
