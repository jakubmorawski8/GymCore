﻿using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class ExerciseHistoryHeaderConfiguration : IEntityTypeConfiguration<ExerciseHistoryHeaderEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseHistoryHeaderEntity> builder)
        {

        }
    }
}