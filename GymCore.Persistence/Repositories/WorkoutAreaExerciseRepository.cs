using System;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutAreaExerciseRepository : BaseRepository<WorkoutAreaExerciseEntity>, IWorkoutAreaExerciseRepository
    {
        public WorkoutAreaExerciseRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<WorkoutAreaExerciseEntity> GetWorkoutAreaExercise(Guid workoutAreaId, Guid exerciseId)
        {
            var userWorkouts = _dbContext.WorkoutAreaExercise
                .Where(entity => entity.ExerciseId == exerciseId && entity.WorkoutAreaId == workoutAreaId)
                .FirstOrDefault();

            return Task.FromResult(userWorkouts);
        }
    }
}
