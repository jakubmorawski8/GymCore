using System;
using System.Collections.Generic;
using System.Linq;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class WorkoutRepositoryMock
    {
        public static Mock<IWorkoutRepository> GetWorkoutRepository()
        {
            #region Init

            var userEntity = new UserEntity() { Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}") };
            var workout1Guid = Guid.Parse("{b7ebdbf9-8e89-464a-b288-1b4b161f713f}");
            var workout2Guid = Guid.Parse("{5791932e-aaa7-4d92-8c04-35717f30d201}");

            var workoutEntities = new List<WorkoutEntity>()
            {
                new WorkoutEntity
                {
                    CreatedBy = userEntity.Id,
                    CreatedDate = DateTime.MinValue,
                    Description = "Full body workout - part A",
                    ModifiedDate = DateTime.MinValue,
                    Id = workout1Guid,
                    Name = "FBWA",
                    UserWorkouts = new List<UserWorkoutEntity>()
                },
                 new WorkoutEntity
                {
                    CreatedBy = userEntity.Id,
                    CreatedDate = DateTime.MinValue,
                    Description = "Full body workout - part B",
                    ModifiedDate = DateTime.MinValue,
                    Id = workout2Guid,
                    Name = "FBWB",
                    UserWorkouts = new List<UserWorkoutEntity>()
                }
            };

            var mockWorkoutRepository = new Mock<IWorkoutRepository>();

            #endregion Init


            #region Queries

            mockWorkoutRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(workoutEntities);

            mockWorkoutRepository.Setup(rep => rep.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) =>
            {
                var result = workoutEntities.Find(w => w.Id == id);
                return result;
            });

            #endregion Queries

            #region Commands

            mockWorkoutRepository.Setup(rep => rep.AddAsync(It.IsAny<WorkoutEntity>())).ReturnsAsync((WorkoutEntity workoutEntity) =>
            {
                workoutEntities.Add(workoutEntity);
                return workoutEntity;
            });

            mockWorkoutRepository.Setup(rep => rep.DeleteAsync(It.IsAny<WorkoutEntity>())).Callback((WorkoutEntity workoutEntity) =>
            {
                workoutEntities.Remove(workoutEntity);
            });

            #endregion Commands

            #region CustomRepositoryMethods

            var workoutForDuplicateTest = workoutEntities.FirstOrDefault();
            mockWorkoutRepository.Setup(rep => rep.IsWorkoutNameUniqueForUser(It.IsIn(workoutForDuplicateTest.Name), It.IsIn(workoutForDuplicateTest.CreatedBy))).ReturnsAsync(false);
            mockWorkoutRepository.Setup(rep => rep.IsWorkoutNameUniqueForUser(It.IsNotIn(workoutForDuplicateTest.Name), It.IsNotIn(workoutForDuplicateTest.CreatedBy))).ReturnsAsync(true);


            mockWorkoutRepository.Setup(rep => rep.GetWorkoutsForUser(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((Guid owner, int page, int pageSize) =>
            {
                var skip = (page - 1) * pageSize;

                var result = workoutEntities.Skip(skip).Take(pageSize).ToList();
                return result;
            });

            #endregion CustomRepositoryMethods

            return mockWorkoutRepository;
        }
    }
}
