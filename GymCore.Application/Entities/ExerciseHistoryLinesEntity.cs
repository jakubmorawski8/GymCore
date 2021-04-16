using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Core.Entities
{
    public class ExerciseHistoryLinesEntity : BaseEntity
    {
        public long ExerciseHistoryHeaderId { get; set; }
        public long ExerciseId { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
