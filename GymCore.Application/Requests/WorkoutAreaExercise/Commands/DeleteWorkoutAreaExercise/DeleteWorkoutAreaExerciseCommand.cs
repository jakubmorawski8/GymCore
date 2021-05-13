using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.DeleteWorkoutAreaExercise
{
    public class DeleteWorkoutAreaExerciseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
