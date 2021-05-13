using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.DeleteWorkoutArea
{
    public class DeleteWorkoutAreaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
