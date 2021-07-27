using System;
using System.Linq;
using GymCore.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GymCore.API.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<GymCoreDbContext>));

                services.Remove(descriptor);
                services.AddDbContext<GymCoreDbContext>(options =>
                {
                    options.UseInMemoryDatabase("GymCOreDbContextInMemoryTest");
                });

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<GymCoreDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                context.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbContext(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Error occurred while initializing database. Error: {ex.Message}");
                }
            });
        }
    }
}
