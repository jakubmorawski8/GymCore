using System;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails
{
    public class GetExerciseDetailsQuery : IRequest<GetExerciseDetailsQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
