using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails
{
    public class GetWorkoutDetailsQueryHandler : IRequestHandler<GetWorkoutDetailsQuery, WorkoutDetailsVm>
    {
        private readonly IRepository<WorkoutEntity> _workoutRepository;
        private readonly IMapper _mapper;
        public GetWorkoutDetailsQueryHandler(IRepository<WorkoutEntity> workoutRepository,
                                                IMapper mapper)
        {
            _mapper = mapper;
            _workoutRepository = workoutRepository;
        }

        public async Task<WorkoutDetailsVm> Handle(GetWorkoutDetailsQuery request, CancellationToken cancellationToken)
        {
            var @event = await _workoutRepository.GetByIdAsync(request.Id);
            var eventDetailDto = _mapper.Map<WorkoutDetailsVm>(@event);

            var user = _mapper.Map<WorkoutUserDto>(@event.CreatedBy);

            eventDetailDto.WorkoutUserDto = user;

            return eventDetailDto;
        }
    }
}
