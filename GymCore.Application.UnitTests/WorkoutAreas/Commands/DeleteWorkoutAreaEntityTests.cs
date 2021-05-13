using System;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Requests.WorkoutArea.Commands.DeleteWorkoutArea;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreas.Commands
{
    public class DeleteWorkoutAreaEntityTests
    {
        private readonly Mock<IWorkoutAreaRepository> _mockWorkoutAreaEntityRepository;

        public DeleteWorkoutAreaEntityTests()
        {
            _mockWorkoutAreaEntityRepository = WorkoutAreaRepositoryMock.GetWorkoutAreaRepository();
        }

        [Fact]
        public async Task Handle_ValidWorkoutArea_AddedToWorkoutAreaRepository()
        {
            var handler = new DeleteWorkoutAreaCommandHandler(_mockWorkoutAreaEntityRepository.Object);
            await handler.Handle(new DeleteWorkoutAreaCommand()
            {
                Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}")
            }, CancellationToken.None);

            var allWorkoutAreas = await _mockWorkoutAreaEntityRepository.Object.ListAllAsync();
            allWorkoutAreas.Count.ShouldBe(0);
        }
    }
}
