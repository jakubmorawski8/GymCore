using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.DeleteWorkoutArea
{
    public class DeleteWorkoutAreaCommandHandler : IRequestHandler<DeleteWorkoutAreaCommand, Unit>
    {
        private readonly IWorkoutAreaRepository _workoutAreaRepository;

        public DeleteWorkoutAreaCommandHandler(IWorkoutAreaRepository workoutAreaRepository)
        {
            _workoutAreaRepository = workoutAreaRepository;
        }

        public async Task<Unit> Handle(DeleteWorkoutAreaCommand request, CancellationToken cancellationToken)
        {
            var workoutArea = await _workoutAreaRepository.GetByIdAsync(request.Id);
            await _workoutAreaRepository.DeleteAsync(workoutArea);

            return Unit.Value;
        }
    }
}
