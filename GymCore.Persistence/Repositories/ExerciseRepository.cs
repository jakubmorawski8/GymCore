using System;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Persistence.Repositories
{
    public class ExerciseRepository : BaseRepository<ExerciseEntity>, IExerciseRepository
    {
        public ExerciseRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsExerciseNameUnique(string exerciseName)
        {
            var matches = !_dbContext.Workout.Any(e => e.Name == exerciseName);
            return Task.FromResult(matches);
        }

        public async Task<bool> ExerciseHasNoRelatedWorkoutHistoryLines(Guid exerciseId)
        {
            var matches = _dbContext.Exercise.Where(e => e.Id == exerciseId).Include(e => e.ExerciseHistoryLines).AnyAsync();
            return !await matches;
        }

        public async Task<bool> ExerciseHasNoRelatedWorkouts(Guid exerciseId)
        {
            var matches = _dbContext.Exercise.Where(e => e.Id == exerciseId).Include(e => e.WorkoutAreasExercise).AnyAsync();
            return !await matches;
        }
    }
}
