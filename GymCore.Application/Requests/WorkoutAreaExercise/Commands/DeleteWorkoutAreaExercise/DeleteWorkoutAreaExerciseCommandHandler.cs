using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.DeleteWorkoutAreaExercise
{
    public class DeleteWorkoutAreaExerciseCommandHandler : IRequestHandler<DeleteWorkoutAreaExerciseCommand>
    {
        private readonly IWorkoutAreaExerciseRepository _workoutAreaExerciseRepository;

        public DeleteWorkoutAreaExerciseCommandHandler(IWorkoutAreaExerciseRepository workoutAreaExerciseRepository)
        {
            _workoutAreaExerciseRepository = workoutAreaExerciseRepository;
        }

        public async Task<Unit> Handle(DeleteWorkoutAreaExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutAreaExercise = await _workoutAreaExerciseRepository.GetByIdAsync(request.Id);
            await _workoutAreaExerciseRepository.DeleteAsync(workoutAreaExercise);

            return Unit.Value;
        }
    }
}
