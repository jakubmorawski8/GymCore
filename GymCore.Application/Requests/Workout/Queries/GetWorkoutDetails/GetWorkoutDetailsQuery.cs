using System;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails
{
    public class GetWorkoutDetailsQuery : IRequest<WorkoutDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
