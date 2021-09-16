using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsListForUser;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.Workout.Queries
{
    public class GetWorkoutsListForUserQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutRepository> _mockWorkoutEntityRepository;

        public GetWorkoutsListForUserQueryHandlerTest()
        {
            _mockWorkoutEntityRepository = WorkoutRepositoryMock.GetWorkoutRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetWorkoutsForUserTest()
        {
            var ownetGuid = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}");
            var page = 1;
            var pageSize = 2;
            var handler = new GetWorkoutsListForUserQueryHandler(_mockWorkoutEntityRepository.Object, _mapper);
            var result = await handler.Handle(new GetWorkoutsListForUserQuery()
            {
                Owner = ownetGuid,
                Page = page,
                Size = pageSize
            }, CancellationToken.None);

            result.ShouldBeOfType<List<WorkoutListVm>>();
            result.Count.ShouldBe(pageSize);
        }
    }
}
