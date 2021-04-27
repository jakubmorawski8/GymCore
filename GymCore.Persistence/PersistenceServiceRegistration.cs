﻿using GymCore.Application.Interfaces;
using GymCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymCore.Persistence
{
    public static class PersistenceServiceRegistration
    {
        private static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
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
            services.AddDbContext<GymCoreDBContext>(csCoreDb);
            #endregion DbContexts

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IExerciseHistoryHeaderRepository, ExerciseHistoryHeaderRepository>();
            services.AddScoped<IExerciseHistoryLinesRepository, ExerciseHistoryLinesRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserWorkoutRepository, UserWorkoutRepository>();
            services.AddScoped<IWorkoutAreaExerciseRepository, WorkoutAreaExerciseRepository>();
            services.AddScoped<IWorkoutAreaRepository, WorkoutAreaRepository>();
            #endregion Repositories

            return services;
        }
    }
}
