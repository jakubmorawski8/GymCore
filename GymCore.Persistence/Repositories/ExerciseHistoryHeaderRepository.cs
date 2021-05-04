using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class ExerciseHistoryHeaderRepository : BaseRepository<ExerciseHistoryHeaderEntity>, IExerciseHistoryHeaderRepository
    {
        public ExerciseHistoryHeaderRepository(GymCoreDBContext dbContext) : base(dbContext)
        {
        }
    }
}
