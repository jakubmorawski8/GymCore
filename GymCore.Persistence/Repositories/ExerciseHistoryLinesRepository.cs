using GymCore.Application.Interfaces;
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
