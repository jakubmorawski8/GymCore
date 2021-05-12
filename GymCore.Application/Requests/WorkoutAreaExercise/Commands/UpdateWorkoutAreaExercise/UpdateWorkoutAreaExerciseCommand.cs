using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.UpdateWorkoutAreaExercise
{
    public class UpdateWorkoutAreaExerciseCommand : IRequest
    {
        public Guid Id { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
