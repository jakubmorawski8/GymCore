using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Exercise.Queries
{
    public class GetExerciseDetailsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IExerciseRepository> _mockExerciseEntityRepository;

        public GetExerciseDetailsQueryHandlerTests()
        {
            _mockExerciseEntityRepository = ExerciseRepositoryMock.GetExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetExerciseDetailsTest()
        {
            var handler = new GetExerciseDetailsQueryHandler(_mockExerciseEntityRepository.Object, _mapper);
            var exerciseEntityToTest = (await _mockExerciseEntityRepository.Object.ListAllAsync()).FirstOrDefault();
            var result = await handler.Handle(new GetExerciseDetailsQuery()
            {
                Id = exerciseEntityToTest.Id
            }, CancellationToken.None);
            result.ShouldBeOfType<ExerciseDetailsVm>();
        }
    }
}
