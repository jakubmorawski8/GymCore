using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class ExerciseHistoryLinesRepository : BaseRepository<ExerciseHistoryLinesEntity>, IExerciseHistoryLinesRepository
    {
        public ExerciseHistoryLinesRepository(GymCoreDBContext dbContext) : base(dbContext)
        {
        }
    }
}
