using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseList;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Exercise.Queries
{
    public class GetExercisesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IExerciseRepository> _mockExerciseEntityRepository;

        public GetExercisesListQueryHandlerTests()
        {
            _mockExerciseEntityRepository = ExerciseRepositoryMock.GetExerciseRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetExercisesListTest()
        {
            var handler = new GetExerciseListQueryHandler(_mockExerciseEntityRepository.Object, _mapper);

            var query = new GetExerciseListQuery();
            query.Page = 1;
            query.Size = 2;
            query.SortField = "CreatedDate";
            query.SortDirection = "asc";
            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<GetExerciseListQueryResponse>();
            result.exercises.ShouldBeOfType<List<ExerciseListVm>>();
            result.exercises.Count.ShouldBe(query.Size);
        }
    }
}
