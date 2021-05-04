using FluentValidation;
using GymCore.Application.Requests.Workout.Commands.CreateWorkout;

namespace GymCore.Application.Requests.Workout.Commands.UpdateWorkout
{
    public class UpdateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
    {
        public UpdateWorkoutCommandValidator()
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
