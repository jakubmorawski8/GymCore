using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using GymCore.Application.Interfaces.Persistence;

namespace GymCore.Application.Requests.Exercise.Commands.DeleteExercise
{
    public class DeleteExerciseCommandValidator : AbstractValidator<DeleteExerciseCommand>
    {
        private readonly IExerciseRepository _exerciseRepository;

        public DeleteExerciseCommandValidator(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;

            RuleFor(e => e.Id)
                .MustAsync(ExerciseHasNoRelatedWorkoutHistoryLines)
                .WithMessage("You cannot delete an exercise because there are related historical activities")
                .MustAsync(ExerciseHasNoRelatedWorkouts)
                .WithMessage("You cannot delete an exercise because there are related workouts");
        }

        private async Task<bool> ExerciseHasNoRelatedWorkoutHistoryLines(Guid exerciseId, CancellationToken token)
        {
            var result = _exerciseRepository.ExerciseHasNoRelatedWorkoutHistoryLines(exerciseId);
            return await result;
        }

        private async Task<bool> ExerciseHasNoRelatedWorkouts(Guid exerciseId, CancellationToken token)
        {
            var result = _exerciseRepository.ExerciseHasNoRelatedWorkouts(exerciseId);
            return await result;
        }

    }
}
