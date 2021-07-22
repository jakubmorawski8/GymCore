using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GymCore.Application.Interfaces.Persistence;

namespace GymCore.Application.Requests.Exercise.Commands.CreateExercise
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;
        public CreateExerciseCommandValidator(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(60).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
                .MustAsync(IsExerciseNameUnique)
                .WithMessage("Exercise with the same name already exists.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        }

        private async Task<bool> IsExerciseNameUnique(string exerciseName, CancellationToken token)
        {
            return await _exerciseRepository.IsExerciseNameUnique(exerciseName);
        }

    }
}
