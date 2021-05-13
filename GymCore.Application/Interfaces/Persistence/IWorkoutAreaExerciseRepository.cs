using System;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IWorkoutAreaExerciseRepository : IRepository<WorkoutAreaExerciseEntity>
    {
        Task<WorkoutAreaExerciseEntity> GetWorkoutAreaExercise(Guid workoutAreaId, Guid exerciseId);
    }
}
