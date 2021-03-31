using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class ExerciseHistoryLinesConfiguration : IEntityTypeConfiguration<ExerciseHistoryLinesEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseHistoryLinesEntity> builder)
        {

        }
    }
}
