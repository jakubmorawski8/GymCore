using System.Collections.Generic;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExercisesListQuery : PaginationList, IRequest<List<ExerciseListVm>>
    {
    }
}
