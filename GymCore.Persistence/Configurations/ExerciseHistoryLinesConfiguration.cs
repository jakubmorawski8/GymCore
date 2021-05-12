using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class ExerciseHistoryLinesConfiguration : BaseEntityConfiguration<ExerciseHistoryLinesEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<ExerciseHistoryLinesEntity> builder)
        {
            builder.HasOne(x => x.Exercise).WithMany(e => e.ExerciseHistoryLines).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ExerciseHistoryHeader);
            builder.HasOne(x => x.Exercise);
            builder.Property(x => x.Load).IsRequired(true);
            builder.Property(x => x.QtyRepetitions).IsRequired(true);
        }
    }
}
