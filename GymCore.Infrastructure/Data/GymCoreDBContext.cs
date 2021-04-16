using GymCore.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Infrastructure.Data
{
    public class GymCoreDBContext : DbContext
    {
        public GymCoreDBContext(DbContextOptions<GymCoreDBContext> options) : base(options)
        {

        }

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
