namespace GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails
{
    public class WorkoutDetailsVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkoutUserDto WorkoutUserDto { get; set; }
    }
}
