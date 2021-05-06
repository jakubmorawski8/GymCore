using System;
using System.Collections.Generic;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class RepositoryMock
    {
        public static Mock<IWorkoutRepository> GetWorkoutRepository()
        {
            var userEntity = new UserEntity() { Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}") };
            var workout1Guid = Guid.Parse("{b7ebdbf9-8e89-464a-b288-1b4b161f713f}");
            var workout2Guid = Guid.Parse("{5791932e-aaa7-4d92-8c04-35717f30d201}");

            var workoutEntities = new List<WorkoutEntity>()
            {
                new WorkoutEntity
                {
                    CreatedBy = userEntity.Id,
                    CreatedDate = DateTime.MinValue,
                    Description = "Test description",
                    ModifiedDate = DateTime.MinValue,
                    Id = workout1Guid,
                    Name = "Test name",
                    UserWorkouts = new List<UserWorkoutEntity>()
                },
                 new WorkoutEntity
                {
                    CreatedBy = userEntity.Id,
                    CreatedDate = DateTime.MinValue,
                    Description = "Test description",
                    ModifiedDate = DateTime.MinValue,
                    Id = workout2Guid,
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
