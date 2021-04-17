using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(GymCoreDBContext dbContext) : base(dbContext)
        {

        }
    }
}
