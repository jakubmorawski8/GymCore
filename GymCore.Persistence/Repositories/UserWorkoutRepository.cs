using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Persistence.Repositories
{
    public class UserWorkoutRepository : BaseRepository<UserWorkoutEntity>, IUserWorkoutRepository
    {
        public UserWorkoutRepository(GymCoreDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<UserWorkoutEntity>> GetPagedReponseAsync(Guid ownerId, int page, int size)
        {
            return await _dbContext.Set<UserWorkoutEntity>().Where(uw => uw.UserId == ownerId).Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }
    }
}
