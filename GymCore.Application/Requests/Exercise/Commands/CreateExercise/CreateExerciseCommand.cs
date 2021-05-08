using System;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Commands.CreateExercise
{
    public class CreateExerciseCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Exercise :{Name}; Description: {Description}";
        }
    }
}
