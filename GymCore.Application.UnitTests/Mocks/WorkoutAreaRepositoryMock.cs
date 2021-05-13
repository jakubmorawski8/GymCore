using System;
using System.Collections.Generic;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class WorkoutAreaRepositoryMock
    {
        public static Mock<IWorkoutAreaRepository> GetWorkoutAreaRepository()
        {
            var workoutAreaEntity = new WorkoutAreaEntity() { Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}"), QtyRepetitions = 1 };

            var workoutAreaEntities = new List<WorkoutAreaEntity>() { workoutAreaEntity };

            var mockUserWorkoutRepository = new Mock<IWorkoutAreaRepository>();

            mockUserWorkoutRepository.Setup(rep => rep.AddAsync(It.IsAny<WorkoutAreaEntity>())).ReturnsAsync((WorkoutAreaEntity entity) =>
            {
                workoutAreaEntities.Add(entity);
                return entity;
            });

            mockUserWorkoutRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(workoutAreaEntities);

            mockUserWorkoutRepository.Setup(rep => rep.GetByIdAsync(It.Is<Guid>(g => g == workoutAreaEntity.Id))).ReturnsAsync(workoutAreaEntity);

            mockUserWorkoutRepository.Setup(rep => rep.DeleteAsync(It.IsAny<WorkoutAreaEntity>())).Callback((WorkoutAreaEntity entity) =>
            {
                workoutAreaEntities.Remove(entity);
            });

            return mockUserWorkoutRepository;
        }
    }
}
