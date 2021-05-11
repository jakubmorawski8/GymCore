using System;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Requests.UserWorkout.Commands.DeleteUserWorkout;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.UserWorkouts.Commands
{
    public class DeleteUserWorkoutEntityTests
    {
        private readonly Mock<IUserWorkoutRepository> _mockUserWorkoutEntityRepository;

        public DeleteUserWorkoutEntityTests()
        {
            _mockUserWorkoutEntityRepository = UserWorkoutRepositoryMock.GetUserWorkoutRepository();
        }

        [Fact]
        public async Task Handle_ValidUserWorkout_DeletedFromWorkoutsRepository()
        {
            var handler = new DeleteUserWorkoutCommandHandler(_mockUserWorkoutEntityRepository.Object);

            await handler.Handle(new DeleteUserWorkoutCommand()
            {
                Id = Guid.Parse("{c4ebdbc9-8e89-464a-b288-1b4b161f713f}")
            },
            CancellationToken.None);

            var allWorkouts = await _mockUserWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(1);
        }
    }
}
