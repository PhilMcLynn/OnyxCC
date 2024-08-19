using Microsoft.EntityFrameworkCore;
using Onyx.Api.Middleware;
using Onyx.Product.Application;
using Onyx.Product.Persistence;
using Onyx.Product.Identity;
using Onyx.Product.Identity.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Onyx.Product.Application.Contracts;
using Onyx.Api.Services;
namespace Onyx.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices( this WebApplicationBuilder builder) 
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ??
                    "https://localhost:7020",
                    builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"])
                .AllowAnyMethod()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyHeader()
                .AllowCredentials()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapIdentityApi<ApplicationUser>();

            app.UseCors("open");

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.MapHealthChecks("health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app; 
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ProductDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // add logging here later
            }
        }
    }
}
