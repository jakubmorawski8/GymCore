using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Core.Entities
{
    public class WorkoutAreaEntity : BaseEntity
    {
        public long WorkoutId { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
