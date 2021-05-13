using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Requests.WorkoutAreaExercise.Commands.DeleteWorkoutAreaExercise;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreaExercises.Commands
{
    public class DeleteWorkoutAreaExerciseCommandTests
    {
        private readonly Mock<IWorkoutAreaExerciseRepository> _mockWorkoutAreaExerciseEntityRepository;

        public DeleteWorkoutAreaExerciseCommandTests()
        {
            _mockWorkoutAreaExerciseEntityRepository = WorkoutAreaExerciseRepositoryMock.GetWorkoutAreaExerciseRepository();
        }

        [Fact]
        public async Task Handle_ValidWorkoutAreaExercise_DeletedFromWorkoutAreaExercisesRepository()
        {
            var handler = new DeleteWorkoutAreaExerciseCommandHandler(_mockWorkoutAreaExerciseEntityRepository.Object);
            var workoutAreaExercises = await _mockWorkoutAreaExerciseEntityRepository.Object.ListAllAsync();
            var workoutAreaExercise = workoutAreaExercises.FirstOrDefault();

            workoutAreaExercises.Count.ShouldBe(1);

            await handler.Handle(new DeleteWorkoutAreaExerciseCommand()
            {
                Id = workoutAreaExercise.Id
            },
            CancellationToken.None);

            workoutAreaExercises.Count.ShouldBe(0);
        }
    }
}
