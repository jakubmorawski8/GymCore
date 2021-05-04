using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Workout.Commands.CreateWorkout;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Workouts.Commands
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
            var createdByGuid = Guid.Parse("{9e1eaff0-0bd2-427b-a8e3-fe7fd4d78ae3}");
            await handler.Handle(new CreateWorkoutCommand()
            {
                Name = "Test workout",
                Description = "Test description",
                CreatedBy = createdByGuid
            },
            CancellationToken.None);

            var allWorkouts = await _mockWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(3);
        }
    }
}
