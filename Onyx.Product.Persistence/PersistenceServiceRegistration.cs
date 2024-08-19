using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Persistence.Repositories;

namespace Onyx.Product.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services
            , IConfiguration configuration) 
        {
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IColourRepository, ColourRepository>(); //???

            return services;
        }
    }
}
