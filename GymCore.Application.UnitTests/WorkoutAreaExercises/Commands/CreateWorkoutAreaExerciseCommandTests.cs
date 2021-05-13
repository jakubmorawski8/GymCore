using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.WorkoutAreaExercise.Commands.CreateWorkoutAreaExercise;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreaExercises.Commands
{
    public class CreateWorkoutAreaExerciseCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutAreaExerciseRepository> _mockWorkoutAreaExerciseEntityRepository;

        public CreateWorkoutAreaExerciseCommandTests()
        {
            _mockWorkoutAreaExerciseEntityRepository = WorkoutAreaExerciseRepositoryMock.GetWorkoutAreaExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidWorkoutAreaExercise_AddedToWorkoutAreaExercisesRepository()
        {
            var handler = new CreateWorkoutAreaExerciseCommandHandler(_mapper, _mockWorkoutAreaExerciseEntityRepository.Object);
            await handler.Handle(new CreateWorkoutAreaExerciseCommand()
            {
                WorkoutAreaId = new Guid(),
                ExerciseId = new Guid()
            },
            CancellationToken.None);

            var allWorkouts = await _mockWorkoutAreaExerciseEntityRepository.Object.ListAllAsync();
            allWorkouts.Count.ShouldBe(2);
        }
    }
}
