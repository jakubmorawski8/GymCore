using System;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IWorkoutRepository : IRepository<WorkoutEntity>
    {
        Task<bool> IsWorkoutNameUniqueForUser(string workoutName, Guid userId);
    }
}
