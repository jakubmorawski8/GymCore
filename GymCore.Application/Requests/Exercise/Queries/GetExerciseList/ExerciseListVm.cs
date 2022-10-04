using System;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class ExerciseListVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
