using System;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IExerciseRepository : IRepository<ExerciseEntity>
    {
        Task<bool> IsExerciseNameUnique(string exerciseName);
        Task<bool> ExerciseHasNoRelatedWorkoutHistoryLines(Guid exerciseId);
        Task<bool> ExerciseHasNoRelatedWorkouts(Guid exerciseId);
    }
}
