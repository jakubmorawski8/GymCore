﻿using GymCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Infrastructure.Data.Configurations
{
    public class ExerciseHistoryLinesConfiguration : IEntityTypeConfiguration<ExerciseHistoryLinesEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseHistoryLinesEntity> builder)
        {

        }
    }
}
