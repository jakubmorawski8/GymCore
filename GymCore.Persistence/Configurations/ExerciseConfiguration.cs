using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class ExerciseConfiguration : BaseEntityConfiguration<WorkoutEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<WorkoutEntity> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired(true);
            builder.Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
