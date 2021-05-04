using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IUserWorkoutRepository : IRepository<UserWorkoutEntity>
    {
        Task<IReadOnlyList<UserWorkoutEntity>> GetPagedReponseAsync(Guid ownerId, int page, int size);
    }
}
