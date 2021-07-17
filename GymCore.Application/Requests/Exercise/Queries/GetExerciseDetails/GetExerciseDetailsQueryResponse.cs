using GymCore.Application.Responses;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails
{
    public class GetExerciseDetailsQueryResponse : BaseResponse
    {
        public ExerciseDetailsVm ExerciseDetailsVm { get; set; }
        public GetExerciseDetailsQueryResponse() : base()
        {

        }
    }
}
