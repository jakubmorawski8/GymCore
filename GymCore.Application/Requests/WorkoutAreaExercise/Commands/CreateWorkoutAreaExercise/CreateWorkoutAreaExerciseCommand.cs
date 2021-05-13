using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.CreateWorkoutAreaExercise
{
    public class CreateWorkoutAreaExerciseCommand : IRequest<Guid>
    {
        public Guid WorkoutAreaId { get; set; }
        public Guid ExerciseId { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
