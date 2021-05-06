using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class ExerciseHistoryLinesRepository : BaseRepository<ExerciseHistoryLinesEntity>, IExerciseHistoryLinesRepository
    {
        public ExerciseHistoryLinesRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
