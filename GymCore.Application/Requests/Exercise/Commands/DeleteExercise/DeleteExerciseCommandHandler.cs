using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Exceptions;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand>
    {
        public IExerciseRepository _exerciseRepository { get; set; }

        public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteExerciseCommandValidator(_exerciseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exerciseToDelete = await _exerciseRepository.GetByIdAsync(request.Id);
            await _exerciseRepository.DeleteAsync(exerciseToDelete);
            return Unit.Value;
        }
    }
}
