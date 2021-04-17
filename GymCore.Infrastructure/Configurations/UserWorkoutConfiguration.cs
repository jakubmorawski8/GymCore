using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Persistence.Configurations
{
    public class UserWorkoutConfiguration : IEntityTypeConfiguration<UserWorkoutEntity>
    {
        public void Configure(EntityTypeBuilder<UserWorkoutEntity> builder)
        {
            builder.HasKey(x => new { x.UserId, x.WorkoutId });
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserWorkouts)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Workout)
                .WithMany(x => x.UserWorkouts)
                .HasForeignKey(x => x.WorkoutId);
        }
    }
}
