using System;
using System.Collections.Generic;
using GymCore.Application.Responses;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExerciseListQueryResponse : BaseResponse
    {
        public List<ExerciseListVm> exercises { get; set; }
        public GetExerciseListQueryResponse() : base()
        {
        }
    }
}

