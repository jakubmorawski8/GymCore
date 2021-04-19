using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Workout.Commands.CreateWorkout;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Categories.Commands
{
    public class CreateWorkoutEntityTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutRepository> _mockWorkoutEntityRepository;

        public CreateWorkoutEntityTests()
        {
            _mockWorkoutEntityRepository = RepositoryMock.GetWorkoutRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidWorkout_AddedToWorkoutsRepository()
        {
            var handler = new CreateWorkoutCommandHandler(_mockWorkoutEntityRepository.Object, _mapper);

            await handler.Handle(new CreateWorkoutCommand()
            {
                Name = "Test workout",
                Description = "Test description",
                Owner = "Test owner"
            },
            CancellationToken.None);

            var allWorkouts = await _mockWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(3);
        }
    }
}
