using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class WorkoutAreaExerciseConfiguration : IEntityTypeConfiguration<WorkoutAreaExerciseEntity>
    {
        public void Configure(EntityTypeBuilder<WorkoutAreaExerciseEntity> builder)
        {

        }
    }
}
