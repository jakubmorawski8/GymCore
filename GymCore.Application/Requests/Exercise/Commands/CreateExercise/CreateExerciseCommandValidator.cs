using FluentValidation;

namespace GymCore.Application.Requests.Exercise.Commands.CreateExercise
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                 .MaximumLength(60).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

        }
    }
}
