using System;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Queries
{
    public class GetWorkoutAreaExerciseQuery : IRequest<WorkoutAreaExerciseVm>
    {
        public Guid WorkoutAreaId { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
