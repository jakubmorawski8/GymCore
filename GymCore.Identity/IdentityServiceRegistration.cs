using GymCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymCore.Identity
{
    public static class IdentityServiceRegistration
    {
        private static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddDbContext<T>(options =>
                options.UseNpgsql(connectionString,
                x => x.MigrationsAssembly(typeof(T).Assembly.FullName)));
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GymCoreIdentityDbContext>(connectionString);
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<GymCoreIdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
