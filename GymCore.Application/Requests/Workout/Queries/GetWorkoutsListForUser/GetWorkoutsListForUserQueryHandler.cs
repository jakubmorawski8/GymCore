using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutsListForUser
{
    public class GetWorkoutsListForUserQueryHandler : IRequestHandler<GetWorkoutsListForUserQuery, List<WorkoutListVm>>
    {
        private readonly IUserWorkoutRepository _userWorkoutRepository;
        private readonly IMapper _mapper;
        public GetWorkoutsListForUserQueryHandler(IUserWorkoutRepository userWorkoutRepository,
                                                IMapper mapper)
        {
            _mapper = mapper;
            _userWorkoutRepository = userWorkoutRepository;
        }
        public async Task<List<WorkoutListVm>> Handle(GetWorkoutsListForUserQuery request, CancellationToken cancellationToken)
        {
            var allWorkouts = (await _userWorkoutRepository.GetPagedReponseAsync(request.Owner, request.page, request.size)).ToList();
            return _mapper.Map<List<WorkoutListVm>>(allWorkouts);
        }
    }
}
