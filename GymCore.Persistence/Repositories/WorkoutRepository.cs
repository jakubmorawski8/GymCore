using System;
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

        public Task<bool> IsWorkoutNameUnitqueForUser(string workoutName, Guid userId)
        {
            var matches = _dbContext.Workout.Any(w => w.CreatedBy == userId && w.Name == workoutName);
            return Task.FromResult(matches);
        }
    }
}
