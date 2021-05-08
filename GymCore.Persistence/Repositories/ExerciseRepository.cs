using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;

namespace GymCore.Persistence.Repositories
{
    public class ExerciseRepository : BaseRepository<ExerciseEntity>, IExerciseRepository
    {
        public ExerciseRepository(GymCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
