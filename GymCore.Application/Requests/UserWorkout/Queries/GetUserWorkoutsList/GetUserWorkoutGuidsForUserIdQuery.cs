using System;
using System.Collections.Generic;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Queries.GetUserWorkoutList
{
    public class GetUserWorkoutGuidsForUserIdQuery : IRequest<List<Guid>>
    {
        public Guid UserId { get; set; }
    }
}
