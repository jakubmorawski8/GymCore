using System;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Commands.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
