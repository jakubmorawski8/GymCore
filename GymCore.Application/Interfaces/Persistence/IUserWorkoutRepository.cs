using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IUserWorkoutRepository : IRepository<UserWorkoutEntity>
    {
        Task<List<Guid>> GetUserWorkoutsForUserId(Guid userId);
    }
}
