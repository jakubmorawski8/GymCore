using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutAreaRepository : BaseRepository<WorkoutAreaEntity>, IWorkoutAreaRepository
    {
        public WorkoutAreaRepository(GymCoreDBContext dbContext) : base(dbContext)
        {
        }
    }
}
