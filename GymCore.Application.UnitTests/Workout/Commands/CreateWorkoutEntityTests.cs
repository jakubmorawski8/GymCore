using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

namespace GymCore.Application.UnitTests.Workout.Commands
{
    public class CreateWorkoutEntityTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutRepository> _mockWorkoutEntityRepository;

        public CreateWorkoutEntityTests()
        {
            _mockWorkoutEntityRepository = WorkoutRepositoryMock.GetWorkoutRepository();

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
                Name = "Split workout",
                Description = "Split workout",
                CreatedBy = createdByGuid
            },
            CancellationToken.None);

            var allWorkouts = await _mockWorkoutEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(3);
        }


        [Fact]
        public async Task Handle_NotValidWorkout_AddedDuplicatedRecordToWorkoutsRepository()
        {
            var handler = new CreateWorkoutCommandHandler(_mockWorkoutEntityRepository.Object, _mapper);
            var workoutForDuplicateTest = (await _mockWorkoutEntityRepository.Object.ListAllAsync()).FirstOrDefault();
            var createdBy = workoutForDuplicateTest.CreatedBy;
            var workoutName = workoutForDuplicateTest.Name;

            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(new CreateWorkoutCommand()
            {
                Name = workoutName,
                Description = "Test description",
                CreatedBy = createdBy
            },
            CancellationToken.None));
        }
    }
}
