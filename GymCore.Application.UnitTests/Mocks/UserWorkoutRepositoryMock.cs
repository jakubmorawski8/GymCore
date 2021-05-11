using System;
using System.Collections.Generic;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class UserWorkoutRepositoryMock
    {
        public static Mock<IUserWorkoutRepository> GetUserWorkoutRepository()
        {
            var userEntity = new UserEntity() { Id = Guid.Parse("{c3ebdbc9-8e89-464a-b288-1b4b161f713f}") };
            var workoutEntity = new WorkoutEntity() { Id = Guid.Parse("{b2ebdbc9-8e89-464a-b288-1b4b161f713f}") };
            var firstUserWorkoutEntityGuid = Guid.Parse("{c4ebdbc9-8e89-464a-b288-1b4b161f713f}");
            var secondUserWorkoutEntityGuid = Guid.Parse("{c1ebdbc9-8e89-464a-b288-1b4b161f713f}");
            var firstUserWorkoutEntity = new UserWorkoutEntity() { Id = firstUserWorkoutEntityGuid, UserId = userEntity.Id, WorkoutId = workoutEntity.Id };
            var secondUserWorkoutEntity = new UserWorkoutEntity() { Id = secondUserWorkoutEntityGuid, UserId = userEntity.Id, WorkoutId = workoutEntity.Id };

            var userWorkoutEntities = new List<UserWorkoutEntity>()
            {
                firstUserWorkoutEntity, secondUserWorkoutEntity
            };

            var mockUserWorkoutRepository = new Mock<IUserWorkoutRepository>();
            mockUserWorkoutRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(userWorkoutEntities);

            mockUserWorkoutRepository.Setup(rep => rep.GetByIdAsync(It.Is<Guid>(g => g == firstUserWorkoutEntityGuid))).ReturnsAsync(firstUserWorkoutEntity);

            mockUserWorkoutRepository.Setup(rep => rep.AddAsync(It.IsAny<UserWorkoutEntity>())).ReturnsAsync((UserWorkoutEntity userWorkoutEntity) =>
            {
                userWorkoutEntities.Add(userWorkoutEntity);
                return userWorkoutEntity;
            });

            mockUserWorkoutRepository.Setup(rep => rep.DeleteAsync(It.IsAny<UserWorkoutEntity>())).Callback((UserWorkoutEntity userWorkoutEntity) =>
            {
                userWorkoutEntities.Remove(userWorkoutEntity);
            });

            return mockUserWorkoutRepository;
        }
    }
}
