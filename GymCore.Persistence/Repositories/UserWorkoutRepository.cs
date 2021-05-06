using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class UserWorkoutRepository : BaseRepository<UserWorkoutEntity>, IUserWorkoutRepository
    {
        public UserWorkoutRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
