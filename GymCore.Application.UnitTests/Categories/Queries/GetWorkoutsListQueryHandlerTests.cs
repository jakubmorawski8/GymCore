using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Categories.Queries
{
    public class GetWorkoutsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutRepository> _mockWorkoutEntityRepository;

        public GetWorkoutsListQueryHandlerTests()
        {
            _mockWorkoutEntityRepository = RepositoryMock.GetWorkoutRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetWorkoutsListTest()
        {
            var handler = new GetWorkoutsListQueryHandler(_mapper, _mockWorkoutEntityRepository.Object);

            var result = await handler.Handle(new GetWorkoutsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<WorkoutListVm>>();
            result.Count.ShouldBe(2);
        }
    }
}
