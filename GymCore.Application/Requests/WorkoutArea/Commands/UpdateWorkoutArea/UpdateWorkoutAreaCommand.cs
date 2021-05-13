using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.UpdateWorkoutArea
{
    public class UpdateWorkoutAreaCommand : IRequest
    {
        public Guid Id { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
