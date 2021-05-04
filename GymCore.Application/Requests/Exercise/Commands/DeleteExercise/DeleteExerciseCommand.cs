using System;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Commands.DeleteExercise
{
    public class DeleteExerciseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
