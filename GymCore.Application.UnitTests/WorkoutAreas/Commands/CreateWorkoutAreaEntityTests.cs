using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Profiles;
using GymCore.Application.Requests.WorkoutArea.Commands.CreateWorkoutArea;
using GymCore.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace GymCore.Application.UnitTests.WorkoutAreas.Commands
{
    public class CreateWorkoutAreaEntityTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWorkoutAreaRepository> _mockWorkoutAreaEntityRepository;

        public CreateWorkoutAreaEntityTests()
        {
            _mockWorkoutAreaEntityRepository = WorkoutAreaRepositoryMock.GetWorkoutAreaRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidWorkoutArea_AddedToWorkoutAreaRepository()
        {
            var handler = new CreateWorkoutAreaCommandHandler(_mockWorkoutAreaEntityRepository.Object, _mapper);
            await handler.Handle(new CreateWorkoutAreaCommand()
            {
                WorkoutId = new Guid(),
                QtyRepetitions = 1
            }, CancellationToken.None);

            var allWorkoutAreas = await _mockWorkoutAreaEntityRepository.Object.ListAllAsync();
            allWorkoutAreas.Count.ShouldBe(2);
        }
    }
}
