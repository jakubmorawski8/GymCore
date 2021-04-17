using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutRepository : BaseRepository<WorkoutEntity>, IWorkoutRepository
    {
        public WorkoutRepository(GymCoreDBContext dbContext) : base(dbContext)
        {

        }
    }
}
