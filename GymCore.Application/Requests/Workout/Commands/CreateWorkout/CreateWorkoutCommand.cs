using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public override string ToString()
        {
            return $"Workout :{Name}; By: {Owner}; Description: {Description}";
        }
    }
}
