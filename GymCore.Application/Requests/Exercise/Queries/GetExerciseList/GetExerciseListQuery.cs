using System.Collections.Generic;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExerciseListQuery : QueryParameters, IRequest<GetExerciseListQueryResponse>
    {
    }
}
