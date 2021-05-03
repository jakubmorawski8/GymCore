using System;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public override string ToString()
        {
            return $"Workout :{Name}; By: {CreatedBy}; Description: {Description}";
        }
    }
}
