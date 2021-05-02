using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutsList
{
    public class GetWorkoutsListQueryHandler : IRequestHandler<GetWorkoutsListQuery, List<WorkoutListVm>>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        public GetWorkoutsListQueryHandler(IMapper mapper, IWorkoutRepository workoutRepository)
        {
            _mapper = mapper;
            _workoutRepository = workoutRepository;
        }
        public async Task<List<WorkoutListVm>> Handle(GetWorkoutsListQuery request, CancellationToken cancellationToken)
        {
            var allWorkouts = (await _workoutRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<WorkoutListVm>>(allWorkouts);
        }
    }
}
