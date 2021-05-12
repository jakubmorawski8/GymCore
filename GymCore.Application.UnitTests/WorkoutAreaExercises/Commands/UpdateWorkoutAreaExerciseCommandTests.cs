using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.WorkoutAreaExercise.Commands.UpdateWorkoutAreaExercise;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreaExercises.Commands
{
    public class UpdateWorkoutAreaExerciseCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutAreaExerciseRepository> _mockWorkoutAreaExerciseEntityRepository;

        public UpdateWorkoutAreaExerciseCommandTests()
        {
            _mockWorkoutAreaExerciseEntityRepository = WorkoutAreaExerciseRepositoryMock.GetWorkoutAreaExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidWorkoutAreaExercise_UpdatedWorkoutAreaExerciseInRepository()
        {
            var handler = new UpdateWorkoutAreaExerciseCommandHandler(_mapper, _mockWorkoutAreaExerciseEntityRepository.Object);
            var workoutAreaExercises = await _mockWorkoutAreaExerciseEntityRepository.Object.ListAllAsync();
            var workoutAreaExercise = workoutAreaExercises.FirstOrDefault();

            workoutAreaExercise.Load.ShouldBe(100);

            await handler.Handle(new UpdateWorkoutAreaExerciseCommand()
            {
                Id = workoutAreaExercise.Id,
                Load = 150.5
            },
            CancellationToken.None);

            workoutAreaExercise.Load.ShouldBe(150.5);
        }
    }
}
