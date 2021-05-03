using System;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.DeleteWorkout
{
    public class DeleteWorkoutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
