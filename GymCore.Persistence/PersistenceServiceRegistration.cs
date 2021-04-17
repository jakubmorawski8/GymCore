using GymCore.Application.Interfaces;
using GymCore.Identity;
using GymCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymCore.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
                options.UseNpgsql(connectionString,
                x => x.MigrationsAssembly(typeof(T).Assembly.FullName))
                );
        }

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContexts
            var csCoreDb = configuration.GetConnectionString("GymCoreDBContext");
            var csIdentityDb = configuration.GetConnectionString("GymCoreIdentityDbContext");
            services.AddDbContext<GymCoreDBContext>(csCoreDb);
            services.AddDbContext<GymCoreIdentityDbContext>(csIdentityDb);
            #endregion DbContexts

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            #endregion Repositories

            return services;
        }
    }
}
