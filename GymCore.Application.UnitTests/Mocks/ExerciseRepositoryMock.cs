using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class ExerciseRepositoryMock
    {
        public static Mock<IExerciseRepository> GetExerciseRepository()
        {
            #region Init

            var exerciseEntities = new List<ExerciseEntity>()
            {
                new ExerciseEntity
                {
                    Id = Guid.Parse("{394d3cf6-1fb7-4fba-9428-aacbe0188ccd}"),
                    Name = "Deadlift",
                    Description = "Deadlift"
                },
                new ExerciseEntity
                {
                    Id = Guid.Parse("{5a697731-dc61-4b27-b286-62d746566b95}"),
                    Name = "Overhead Press",
                    Description = "Overhead Press"
                },
                new ExerciseEntity
                {
                    Id = Guid.Parse("{042d38c5-bc8b-4c32-9f96-03cc47780ccb}"),
                    Name = "Leg press",
                    Description = "Leg press"
                }

            };

            var mockExerciseRepository = new Mock<IExerciseRepository>();

            #endregion Init

            #region Queries

            mockExerciseRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(exerciseEntities);
            mockExerciseRepository.Setup(rep => rep.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) =>
            {
                var result = exerciseEntities.Find(e => e.Id == id);
                return result;
            });

            mockExerciseRepository.Setup(rep => rep.GetPagedResponseAsync(It.IsAny<IQueryable<ExerciseEntity>>(), It.IsAny<int>(), It.IsAny<int>()))
               .ReturnsAsync((IQueryable<ExerciseEntity> q, int page, int pageSize) =>
               {
                   var skip = (page - 1) * pageSize;
                   var result = exerciseEntities.Skip(skip).Take(pageSize).ToList();
                   return result;
               });

            #endregion Queries

            #region Commands

            mockExerciseRepository.Setup(rep => rep.AddAsync(It.IsAny<ExerciseEntity>())).ReturnsAsync((ExerciseEntity exerciseEntity) =>
            {
                exerciseEntities.Add(exerciseEntity);
                return exerciseEntity;
            });

            mockExerciseRepository.Setup(rep => rep.DeleteAsync(It.IsAny<ExerciseEntity>())).Callback((ExerciseEntity exerciseEntity) =>
            {
                exerciseEntities.Remove(exerciseEntity);
            });

            #endregion Commands

            #region CustomRepositoryMethods
            var exerciseForTest = exerciseEntities.FirstOrDefault();
            mockExerciseRepository.Setup(rep => rep.IsExerciseNameUnique(It.IsIn(exerciseForTest.Name))).ReturnsAsync(false);
            mockExerciseRepository.Setup(rep => rep.IsExerciseNameUnique(It.IsNotIn(exerciseForTest.Name))).ReturnsAsync(true);

            mockExerciseRepository.Setup(rep => rep.ExerciseHasNoRelatedWorkoutHistoryLines(It.IsIn(exerciseForTest.Id))).ReturnsAsync(false);
            mockExerciseRepository.Setup(rep => rep.ExerciseHasNoRelatedWorkoutHistoryLines(It.IsNotIn(exerciseForTest.Id))).ReturnsAsync(true);

            mockExerciseRepository.Setup(rep => rep.ExerciseHasNoRelatedWorkouts(It.IsIn(exerciseForTest.Id))).ReturnsAsync(false);
            mockExerciseRepository.Setup(rep => rep.ExerciseHasNoRelatedWorkouts(It.IsNotIn(exerciseForTest.Id))).ReturnsAsync(true);

            #endregion CustomRepositoryMethods

            return mockExerciseRepository;
        }
    }
}
