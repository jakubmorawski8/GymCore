using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GymCore.Application.Interfaces;
using GymCore.Application.Interfaces.Persistence;

namespace GymCore.Application.Requests.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        public CreateWorkoutCommandValidator(IWorkoutRepository workoutRepository,ILoggedInUserService loggedInUserService)
        {
            _workoutRepository = workoutRepository;
            _loggedInUserService = loggedInUserService;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(60).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p)
                .MustAsync(WorkoutNameUniqueForUser)
                .WithMessage("Workout with the same name already exists for current user");
        }


        private async Task<bool> WorkoutNameUniqueForUser(CreateWorkoutCommand e, CancellationToken token)
        {
            return !(await _workoutRepository.IsWorkoutNameUnitqueForUser(e.Name, _loggedInUserService.UserId));
        }


    }
}
