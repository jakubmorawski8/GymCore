using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutRepository : BaseRepository<WorkoutEntity>, IWorkoutRepository
    {
        public WorkoutRepository(GymCoreDBContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsWorkoutNameUnitqueForUser(string workoutName, long userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
