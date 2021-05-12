using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Workout.Commands.DeleteWorkout;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Workout.Commands
{
    public class DeleteWorkoutEntityTest
    {
        private readonly Mock<IWorkoutRepository> _mockWorkoutEntityRepository;


        public DeleteWorkoutEntityTest()
        {
            _mockWorkoutEntityRepository = WorkoutRepositoryMock.GetWorkoutRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        [Fact]
        public async Task Handle_ValidWorkout_DeletedToWorkoutsRepository()
        {
            var customTxt = "workout has not been deleted";
            var handler = new DeleteWorkoutCommandHandler(_mockWorkoutEntityRepository.Object);
            var workoutToDeleteGuid = Guid.Parse("{b7ebdbf9-8e89-464a-b288-1b4b161f713f}");
            await handler.Handle(new DeleteWorkoutCommand()
            {
                Id = workoutToDeleteGuid
            },
            CancellationToken.None);


            var allWorkouts = await _mockWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(1, customTxt);
        }
    }
}
