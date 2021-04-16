using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Core.Entities
{
    public class ExerciseHistoryHeaderEntity : BaseEntity
    {
        public long WorkoutId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public long UserId { get; set; }

    }
}
