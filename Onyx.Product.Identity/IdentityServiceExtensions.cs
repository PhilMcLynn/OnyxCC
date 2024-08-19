using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onyx.Product.Identity.Models;

namespace Onyx.Product.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

            //services.AddAuthorizationBuilder();

            services.AddDbContext<ProductIdentityDbContext>(options =>
            {
                options.UseInMemoryDatabase("AuthDb");
            });

            services.AddAuthorization();

            services.AddIdentityApiEndpoints<ApplicationUser>()
                .AddEntityFrameworkStores<ProductIdentityDbContext>();

            //services.AddIdentityCore<ApplicationUser>()
            //    .AddEntityFrameworkStores<ProductIdentityDbContext>()
            //    .AddApiEndpoints();
        }
    }
}
