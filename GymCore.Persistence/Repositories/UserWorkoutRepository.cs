using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class UserWorkoutRepository : BaseRepository<UserWorkoutEntity>, IUserWorkoutRepository
    {
        public UserWorkoutRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Guid>> GetUserWorkoutsForUserId(Guid userId)
        {
            var userWorkouts = _dbContext.UserWorkout.Where(u => u.UserId == userId).Select(u => u.Id);
            return Task.FromResult(userWorkouts.ToList());
        }
    }
}
