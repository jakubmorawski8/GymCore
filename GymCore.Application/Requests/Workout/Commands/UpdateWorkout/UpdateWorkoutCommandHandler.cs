using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.UpdateWorkout
{
    public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand>
    {
        public IWorkoutRepository _workoutRepository { get; set; }
        public IMapper _mapper { get; set; }
        public UpdateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workoutToUpdate = await _workoutRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, workoutToUpdate, typeof(UpdateWorkoutCommand), typeof(WorkoutEntity));
            await _workoutRepository.UpdateAsync(workoutToUpdate);
            return Unit.Value;
        }
    }
}
