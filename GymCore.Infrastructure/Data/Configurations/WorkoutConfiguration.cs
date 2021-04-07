using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<WorkoutEntity>
    {
        public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
        {

        }
    }
}
