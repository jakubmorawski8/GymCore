using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.UserWorkout.Commands.CreateUserWorkout;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.UserWorkouts.Commands
{
    public class CreateUserWorkoutEntityTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserWorkoutRepository> _mockUserWorkoutEntityRepository;

        public CreateUserWorkoutEntityTests()
        {
            _mockUserWorkoutEntityRepository = UserWorkoutRepositoryMock.GetUserWorkoutRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUserWorkout_AddedToWorkoutsRepository()
        {
            var handler = new CreateUserWorkoutCommandHandler(_mockUserWorkoutEntityRepository.Object, _mapper);
            await handler.Handle(new CreateUserWorkoutCommand()
            {
                UserId = new Guid(),
                WorkoutId = new Guid()
            },
            CancellationToken.None);

            var allWorkouts = await _mockUserWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(3);
        }
    }
}
