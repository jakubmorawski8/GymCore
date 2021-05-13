using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Exceptions;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Exercise.Commands.DeleteExercise;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Exercise.Commands
{
    public class DeleteExerciseEntityTest
    {
        private readonly Mock<IExerciseRepository> _mockExerciseRepository;

        public DeleteExerciseEntityTest()
        {
            _mockExerciseRepository = ExerciseRepositoryMock.GetExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        [Fact]
        public async Task Handle_ValidExercise_DeletedToExerciseRepository()
        {
            var customTxt = "exercise has not been deleted";
            var handler = new DeleteExerciseCommandHandler(_mockExerciseRepository.Object);
            var exerciseToTest = (await _mockExerciseRepository.Object.ListAllAsync()).LastOrDefault();


            await handler.Handle(new DeleteExerciseCommand()
            {
                Id = exerciseToTest.Id
            },
            CancellationToken.None);

            var allExercises = await _mockExerciseRepository.Object.ListAllAsync();
            allExercises.Count.ShouldBe(1, customTxt);

        }

        [Fact]
        public async Task Handle_NotValidExercise_DeletedToExerciseRepository()
        {
            var handler = new DeleteExerciseCommandHandler(_mockExerciseRepository.Object);
            var exerciseToTest = (await _mockExerciseRepository.Object.ListAllAsync()).FirstOrDefault();

            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(new DeleteExerciseCommand()
            {
                Id = exerciseToTest.Id
            },
            CancellationToken.None));

            var allExercises = await _mockExerciseRepository.Object.ListAllAsync();
        }
    }
}
