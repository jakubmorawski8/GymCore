using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GymCore.Application.Interfaces.Persistence;

namespace GymCore.Application.Requests.Exercise.Commands.UpdateExercise
{
    public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;
        public UpdateExerciseCommandValidator(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(p => $"{nameof(p.Name)} is required.")
                .NotNull()
                .MaximumLength(60).WithMessage(p => $"{nameof(p.Name)} must not exceed 50 characters.")
                .MustAsync(IsExerciseNameUnique)
                .WithMessage("Exercise with the same name already exists.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage(p => $"{nameof(p.Description)} must not exceed 1000 characters.");
        }

        private async Task<bool> IsExerciseNameUnique(string exerciseName, CancellationToken token)
        {
            return await _exerciseRepository.IsExerciseNameUnique(exerciseName);
        }
    }
}
