using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GymCore.Application.Interfaces.Persistence;

namespace GymCore.Application.Requests.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;
        public CreateWorkoutCommandValidator(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(p => $"{nameof(p.Name)} is required.")
                .NotNull()
                .MaximumLength(60).WithMessage(p => $"{nameof(p.Name)} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage(p => $"{nameof(p.Description)} must not exceed 1000 characters.");

            RuleFor(p => p)
                .MustAsync(WorkoutNameUniqueForUser)
                .WithMessage("Workout with the same name already exists for current user.");

            RuleFor(p => p.CreatedBy)
                .NotEmpty().WithMessage(p => $"{nameof(p.CreatedBy)} is required.")
                .NotNull();
        }

        private async Task<bool> WorkoutNameUniqueForUser(CreateWorkoutCommand e, CancellationToken token)
        {
            return await _workoutRepository.IsWorkoutNameUniqueForUser(e.Name, e.CreatedBy);
        }


    }
}
