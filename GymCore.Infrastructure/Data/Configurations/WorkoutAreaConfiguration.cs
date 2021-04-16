using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class WorkoutAreaConfiguration : BaseEntityConfiguration<WorkoutAreaEntity>
    {
        public override void ConfigureEntityProperties(EntityTypeBuilder<WorkoutAreaEntity> builder)
        {
            builder.HasOne(x => x.Workout);
            builder.Property(x => x.QtyRepetitions).IsRequired(true);
        }
    }
}
