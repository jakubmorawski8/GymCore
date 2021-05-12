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

        public DbSet<WorkoutEntity> Workouts { get; set; }
        public DbSet<UserWorkoutEntity> UserWorkout { get; set; }
        public DbSet<WorkoutAreaExerciseEntity> WorkoutAreaExercise { get; set; }

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
