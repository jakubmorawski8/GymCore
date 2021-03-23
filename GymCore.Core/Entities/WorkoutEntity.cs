using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Core.Entities
{
    public class WorkoutEntity : BaseEntity
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        //public string CreatedBy { get; set; } //TODO - to determine whether it should be id or username ...
    }
}
