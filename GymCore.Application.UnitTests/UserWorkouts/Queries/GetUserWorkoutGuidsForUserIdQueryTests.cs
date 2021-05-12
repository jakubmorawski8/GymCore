using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Requests.UserWorkout.Queries.GetUserWorkoutList;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.UserWorkouts.Queries
{
    public class GetUserWorkoutGuidsForUserIdQueryTests
    {
        private readonly Mock<IUserWorkoutRepository> _mockWorkoutEntityRepository;

        public GetUserWorkoutGuidsForUserIdQueryTests()
        {
            _mockWorkoutEntityRepository = UserWorkoutRepositoryMock.GetUserWorkoutRepository();
        }

        [Fact]
        public async Task GetUserWorkoutGuidsForUserIdQueryTest()
        {
            var handler = new GetUserWorkoutGuidsForUserIdQueryHandler(_mockWorkoutEntityRepository.Object);

            var result = await handler.Handle(new GetUserWorkoutGuidsForUserIdQuery()
            { UserId = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}") },
                CancellationToken.None);

            result.ShouldBeOfType<List<Guid>>();
            result.FirstOrDefault().ShouldBe(Guid.Parse("{c4ebdbc9-8e89-464a-b288-1b4b161f713f}"));
            result.Count.ShouldBe(1);
        }
    }
}
