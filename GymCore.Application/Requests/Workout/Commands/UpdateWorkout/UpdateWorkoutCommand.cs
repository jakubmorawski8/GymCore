﻿using System;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.UpdateWorkout
{
    public class UpdateWorkoutCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
