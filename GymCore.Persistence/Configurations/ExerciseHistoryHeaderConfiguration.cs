using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class ExerciseHistoryHeaderConfiguration : BaseEntityConfiguration<ExerciseHistoryHeaderEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<ExerciseHistoryHeaderEntity> builder)
        {
            builder.Property(x => x.StartDateTime)
                .IsRequired(true);
            builder.Property(x => x.EndDateTime)
                .IsRequired(true);
            builder.HasOne(x => x.Workout);
        }
    }
}
