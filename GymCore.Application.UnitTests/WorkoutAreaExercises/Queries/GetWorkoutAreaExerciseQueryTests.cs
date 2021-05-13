using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.WorkoutAreaExercise.Queries;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreaExercises.Queries
{
    public class GetWorkoutAreaExerciseQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutAreaExerciseRepository> _mockWorkoutAreaExerciseEntityRepository;

        public GetWorkoutAreaExerciseQueryTests()
        {
            _mockWorkoutAreaExerciseEntityRepository = WorkoutAreaExerciseRepositoryMock.GetWorkoutAreaExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetWorkoutAreaExerciseTest()
        {
            var handler = new GetWorkoutAreaExerciseQueryHandler(_mapper, _mockWorkoutAreaExerciseEntityRepository.Object);
            var workoutAreaExercise = (await _mockWorkoutAreaExerciseEntityRepository.Object.ListAllAsync()).FirstOrDefault();

            var result = await handler.Handle(new GetWorkoutAreaExerciseQuery()
            {
                ExerciseId = workoutAreaExercise.ExerciseId,
                WorkoutAreaId = workoutAreaExercise.WorkoutAreaId
            }, CancellationToken.None);

            result.ShouldBeOfType<WorkoutAreaExerciseVm>();
            result.ShouldBeEquivalentTo(_mapper.Map<WorkoutAreaExerciseVm>(workoutAreaExercise));
        }
    }
}
