using System;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Commands.CreateUserWorkout
{
    public class CreateUserWorkoutCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid WorkoutId { get; set; }
    }
}
