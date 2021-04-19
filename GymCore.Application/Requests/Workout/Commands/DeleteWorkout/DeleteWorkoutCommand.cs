using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.DeleteWorkout
{
    public class DeleteWorkoutCommand : IRequest
    {
        public long Id { get; set; }
    }
}
