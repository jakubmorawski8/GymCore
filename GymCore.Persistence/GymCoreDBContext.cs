using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Domain.Entities;
using GymCore.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Persistence
{
    public class GymCoreDbContext : DbContext
    {
        public GymCoreDbContext(DbContextOptions<GymCoreDbContext> options) : base(options)
        {

        }

        public DbSet<WorkoutEntity> Workout { get; set; }
        public DbSet<ExerciseEntity> Exercise { get; set; }
        public DbSet<UserWorkoutEntity> UserWorkout { get; set; }
        public DbSet<WorkoutEntity> Workouts { get; set; }
        public DbSet<WorkoutAreaExerciseEntity> WorkoutAreaExercise { get; set; }

        public DbSet<LogEntity> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserWorkoutConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseHistoryHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseHistoryLinesConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutAreaConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutAreaExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                E.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
