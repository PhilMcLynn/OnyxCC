using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onyx.Product.Persistence;

namespace Onyx.Product.Identity
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("AppConnectionString"))
                .AddDbContextCheck<ProductDbContext>();
        }
    }
}
