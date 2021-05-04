using GymCore.Domain.Entities;
using GymCore.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Persistence
{
    public class GymCoreDBContext : DbContext
    {
        public GymCoreDBContext(DbContextOptions<GymCoreDBContext> options) : base(options)
        {

        }

        public DbSet<WorkoutEntity> Workout { get; set; }
        public DbSet<UserWorkoutEntity> UserWorkout { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserWorkoutConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseHistoryHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseHistoryLinesConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutAreaConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutAreaExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        }
    }
}
