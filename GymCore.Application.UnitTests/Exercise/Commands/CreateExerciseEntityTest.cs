using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Exceptions;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Exercise.Commands.CreateExercise;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Exercise.Commands
{
    public class CreateExerciseEntityTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IExerciseRepository> _mockExerciseRepository;

        public CreateExerciseEntityTest()
        {
            _mockExerciseRepository = ExerciseRepositoryMock.GetExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidExercise_AddedToExerciseRepository()
        {
            var handler = new CreateExerciseCommandHandler(_mapper, _mockExerciseRepository.Object);
            await handler.Handle(new CreateExerciseCommand()
            {
                Name = "Dumbbell Row",
                Description = "Dumbbell Row"
            },
            CancellationToken.None);

            var allExercises = await _mockExerciseRepository.Object.ListAllAsync();
            allExercises.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_NotValidWorkout_AddedDuplicateRecordToExerciseRepository()
        {
            var handler = new CreateExerciseCommandHandler(_mapper, _mockExerciseRepository.Object);
            var exerciseForDuplicateTest = (await _mockExerciseRepository.Object.ListAllAsync()).FirstOrDefault();
            var exerciseName = exerciseForDuplicateTest.Name;

            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(new CreateExerciseCommand()
            {
                Name = exerciseName,
                Description = "",

            }, CancellationToken.None));
        }

    }
}
