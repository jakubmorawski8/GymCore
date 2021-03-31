using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class UserWorkoutConfiguration : IEntityTypeConfiguration<UserWorkoutEntity>
    {
        public void Configure(EntityTypeBuilder<UserWorkoutEntity> builder)
        {

        }
    }
}
