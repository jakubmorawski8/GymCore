using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Queries.GetUserWorkoutList
{
    public class GetUserWorkoutGuidsForUserIdQueryHandler : IRequestHandler<GetUserWorkoutGuidsForUserIdQuery, List<Guid>>
    {
        private readonly IUserWorkoutRepository _userWorkoutRepository;

        public GetUserWorkoutGuidsForUserIdQueryHandler(IUserWorkoutRepository userWorkoutRepository)
        {
            _userWorkoutRepository = userWorkoutRepository;
        }

        public async Task<List<Guid>> Handle(GetUserWorkoutGuidsForUserIdQuery request, CancellationToken cancellationToken)
        {
            var userWorkouts = await _userWorkoutRepository.GetUserWorkoutsForUserId(request.UserId);

            return userWorkouts;
        }
    }
}
