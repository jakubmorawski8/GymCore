using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.WorkoutArea.Commands.UpdateWorkoutArea;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreas.Commands
{
    public class UpdateWorkoutAreaEntityTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutAreaRepository> _mockWorkoutAreaEntityRepository;

        public UpdateWorkoutAreaEntityTests()
        {
            _mockWorkoutAreaEntityRepository = WorkoutAreaRepositoryMock.GetWorkoutAreaRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidWorkoutArea_UpdatedWorkoutAreaEntity()
        {
            var handler = new UpdateWorkoutAreaCommandHandler(_mockWorkoutAreaEntityRepository.Object, _mapper);
            var workoutAreaBeforeUpdate = (await _mockWorkoutAreaEntityRepository.Object.ListAllAsync()).FirstOrDefault();
            workoutAreaBeforeUpdate.QtyRepetitions.ShouldBe(1);

            await handler.Handle(new UpdateWorkoutAreaCommand()
            {
                Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}"),
                QtyRepetitions = 2
            }, CancellationToken.None);

            workoutAreaBeforeUpdate.QtyRepetitions.ShouldBe(2);
        }
    }
}
