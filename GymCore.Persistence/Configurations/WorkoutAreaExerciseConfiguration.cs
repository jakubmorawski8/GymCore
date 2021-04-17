using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class WorkoutAreaExerciseConfiguration : BaseEntityConfiguration<WorkoutAreaExerciseEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<WorkoutAreaExerciseEntity> builder)
        {
            builder
                .HasKey(x => new { x.WorkoutAreaId, x.ExerciseId });
            builder
                .HasOne(x => x.WorkoutArea)
                .WithMany(x => x.WorkoutAreasExercise)
                .HasForeignKey(x => x.WorkoutAreaId);
            builder
                .HasOne(x => x.Exercise)
                .WithMany(x => x.WorkoutAreasExercise)
                .HasForeignKey(x => x.ExerciseId);

            builder
                .Property(x => x.Load).IsRequired(true);
            builder
                .Property(x => x.QtyRepetitions).IsRequired(true);
        }
    }
}
