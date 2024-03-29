﻿using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutAreaRepository : BaseRepository<WorkoutAreaEntity>, IWorkoutAreaRepository
    {
        public WorkoutAreaRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
