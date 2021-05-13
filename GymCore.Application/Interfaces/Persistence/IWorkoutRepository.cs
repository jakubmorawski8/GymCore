using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IWorkoutRepository : IRepository<WorkoutEntity>
    {
        Task<bool> IsWorkoutNameUniqueForUser(string workoutName, Guid userId);

        Task<IReadOnlyList<WorkoutEntity>> GetWorkoutsForUser(Guid userId, int page, int pageSize);
    }

}
