﻿using System.Collections.Generic;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutsList
{
    public class GetWorkoutsListQuery : PaginationList, IRequest<List<WorkoutListVm>>
    {
    }
}
