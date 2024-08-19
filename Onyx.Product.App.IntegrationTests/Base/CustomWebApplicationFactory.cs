using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Onyx.Product.Persistence;

namespace Onyx.Product.App.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Debug"); // IntegrationTest");
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<ProductDbContext>(options =>
                {
                    options.UseInMemoryDatabase("ProductDbContextInMemoryTest");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<ProductDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<TProgram>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utils.InitDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                };
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}
