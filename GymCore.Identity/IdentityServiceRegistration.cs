using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymCore.Identity
{
    public static class IdentityServiceRegistration
    {
        private static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
                options.UseNpgsql(connectionString,
                x => x.MigrationsAssembly(typeof(T).Assembly.FullName))
                );
        }

        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var csIdentityDb = configuration.GetConnectionString("GymCoreIdentityDbContext");
            services.AddDbContext<GymCoreIdentityDbContext>(csIdentityDb);
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<GymCoreIdentityDbContext>();
        }
    }
}
