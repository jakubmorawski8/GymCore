using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class WorkoutAreaConfiguration : IEntityTypeConfiguration<WorkoutAreaEntity>
    {
        public void Configure(EntityTypeBuilder<WorkoutAreaEntity> builder)
        {

        }
    }
}
