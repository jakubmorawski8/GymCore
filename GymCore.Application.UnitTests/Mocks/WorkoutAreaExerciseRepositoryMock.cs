using System;
using System.Collections.Generic;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using Moq;

namespace GymCore.Application.UnitTests.Mocks
{
    public class WorkoutAreaExerciseRepositoryMock
    {
        public static Mock<IWorkoutAreaExerciseRepository> GetWorkoutAreaExerciseRepository()
        {
            var workoutAreaExercise = new WorkoutAreaExerciseEntity()
            {
                Id = new Guid(),
                ExerciseId = new Guid(),
                WorkoutAreaId = new Guid(),
                Load = 100
            };

            var workoutAreaExercises = new List<WorkoutAreaExerciseEntity>()
            {
                workoutAreaExercise
            };

            var mockWorkoutAreaExerciseRepository = new Mock<IWorkoutAreaExerciseRepository>();

            mockWorkoutAreaExerciseRepository
                .Setup(rep => rep.AddAsync(It.IsAny<WorkoutAreaExerciseEntity>()))
                .ReturnsAsync((WorkoutAreaExerciseEntity entity) =>
                {
                    workoutAreaExercises.Add(entity);

                    return entity;
                });

            mockWorkoutAreaExerciseRepository.Setup(rep => rep.ListAllAsync()).ReturnsAsync(workoutAreaExercises);

            mockWorkoutAreaExerciseRepository.Setup(rep => rep.GetByIdAsync(It.Is<Guid>(g => g == workoutAreaExercise.Id))).ReturnsAsync(workoutAreaExercise);

            mockWorkoutAreaExerciseRepository.Setup(rep => rep.DeleteAsync(It.Is<WorkoutAreaExerciseEntity>(entity => entity == workoutAreaExercise)))
                .Callback((WorkoutAreaExerciseEntity entity) =>
                {
                    workoutAreaExercises.Remove(entity);
                });

            mockWorkoutAreaExerciseRepository.Setup(rep => rep.GetWorkoutAreaExercise(It.Is<Guid>(g => g == workoutAreaExercise.WorkoutAreaId),
                It.Is<Guid>(g => g == workoutAreaExercise.ExerciseId))).ReturnsAsync(workoutAreaExercise);

            return mockWorkoutAreaExerciseRepository;

        }
    }
}
