using System;
using System.Collections.Generic;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutsListForUser
{
    public class GetWorkoutsListForUserQuery : PaginationList, IRequest<List<WorkoutListVm>>
    {
        public Guid Owner { get; set; }
    }
}
