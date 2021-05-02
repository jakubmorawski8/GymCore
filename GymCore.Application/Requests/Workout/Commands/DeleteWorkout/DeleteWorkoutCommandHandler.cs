using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.DeleteWorkout
{
    public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand>
    {
        public IWorkoutRepository _workoutRepository { get; set; }
        public IMapper _mapper { get; set; }
        public DeleteWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _mapper = mapper;
            _workoutRepository = workoutRepository;
        }
        public async Task<Unit> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workoutToDelete = await _workoutRepository.GetByIdAsync(request.Id);
            await _workoutRepository.DeleteAsync(workoutToDelete);
            return Unit.Value;
        }
    }
}
