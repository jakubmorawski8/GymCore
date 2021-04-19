using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails
{
    public class GetWorkoutDetailsQueryHandler : IRequestHandler<GetWorkoutDetailsQuery, WorkoutDetailsVm>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        public GetWorkoutDetailsQueryHandler(IWorkoutRepository workoutRepository,
                                                IMapper mapper)
        {
            _mapper = mapper;
            _workoutRepository = workoutRepository;
        }

        public async Task<WorkoutDetailsVm> Handle(GetWorkoutDetailsQuery request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.Id);
            var workoutDetailDto = _mapper.Map<WorkoutDetailsVm>(workout);

            var user = _mapper.Map<WorkoutUserDto>(workout.CreatedBy);

            workoutDetailDto.WorkoutUserDto = user;

            return workoutDetailDto;
        }
    }
}
