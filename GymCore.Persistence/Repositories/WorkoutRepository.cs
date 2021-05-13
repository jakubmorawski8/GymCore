using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutRepository : BaseRepository<WorkoutEntity>, IWorkoutRepository
    {
        public WorkoutRepository(GymCoreDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsWorkoutNameUniqueForUser(string workoutName, Guid userId)
        {
            var matches = !_dbContext.Workout.Any(w => w.CreatedBy == userId && w.Name == workoutName);
            return Task.FromResult(matches);
        }

        public Task<IReadOnlyList<WorkoutEntity>> GetWorkoutsForUser(Guid userId, int page, int pageSize)
        {
            var query = _dbContext.Workout.Where(w => w.CreatedBy == userId);
            var workouts = base.GetPagedResponseAsync(query, page, pageSize);
            return workouts;
        }
    }
}
