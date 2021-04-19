using System;
using System.Collections.Generic;
using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class RepositoryMock
    {
        public static Mock<IWorkoutRepository> GetWorkoutRepository()
        {
            var userEntity = new UserEntity();

            var workoutEntities = new List<WorkoutEntity>()
            {
                new WorkoutEntity
                {
                    CreatedBy = userEntity,
                    CreatedDate = DateTime.MinValue,
                    Description = "Test description",
                    ModifiedDate = DateTime.MinValue,
                    Id = 1,
                    Name = "Test name",
                    UserWorkouts = new List<UserWorkoutEntity>()
                },
                 new WorkoutEntity
                {
                    CreatedBy = userEntity,
                    CreatedDate = DateTime.MinValue,
                    Description = "Test description",
                    ModifiedDate = DateTime.MinValue,
                    Id = 2,
                    Name = "Test name",
                    UserWorkouts = new List<UserWorkoutEntity>()
                }
            };

            var mockWorkoutRepository = new Mock<IWorkoutRepository>();
            mockWorkoutRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(workoutEntities);

            mockWorkoutRepository.Setup(rep => rep.AddAsync(It.IsAny<WorkoutEntity>())).ReturnsAsync((WorkoutEntity workoutEntity) =>
            {
                workoutEntities.Add(workoutEntity);
                return workoutEntity;
            });

            return mockWorkoutRepository;
        }
    }
}
