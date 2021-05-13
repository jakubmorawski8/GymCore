using System;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Commands.DeleteUserWorkout
{
    public class DeleteUserWorkoutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
