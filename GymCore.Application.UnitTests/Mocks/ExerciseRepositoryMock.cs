using System;
using System.Collections.Generic;
using System.Linq;
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
