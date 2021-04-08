﻿using System;

namespace GymCore.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}