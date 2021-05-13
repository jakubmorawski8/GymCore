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
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        public GetWorkoutsListForUserQueryHandler(IWorkoutRepository workoutRepository,
                                                IMapper mapper)
        {
            _mapper = mapper;
            _workoutRepository = workoutRepository;
        }
        public async Task<List<WorkoutListVm>> Handle(GetWorkoutsListForUserQuery request, CancellationToken cancellationToken)
        {
            var allWorkouts = (await _workoutRepository.GetWorkoutsForUser(request.Owner, request.page, request.size)).ToList();
            return _mapper.Map<List<WorkoutListVm>>(allWorkouts);
        }
    }
}
