using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class WorkoutAreaExerciseRepository : BaseRepository<WorkoutAreaExerciseEntity>, IWorkoutAreaExerciseRepository
    {
        public WorkoutAreaExerciseRepository(GymCoreDBContext dbContext) : base(dbContext)
        {
        }
    }
}
