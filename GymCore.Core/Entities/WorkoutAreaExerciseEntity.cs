namespace GymCore.Core.Entities
{
    public class WorkoutAreaExerciseEntity : BaseEntity
    {
        public long WorkoutAreaId { get; set; }
        public long ExerciseId { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
