using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.CreateWorkoutArea
{
    public class CreateWorkoutAreaCommand : IRequest<Guid>
    {
        public Guid WorkoutId { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
