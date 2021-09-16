using System;
using GymCore.Domain.Entities;
using GymCore.Persistence;

namespace GymCore.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbContext(GymCoreDbContext context)
        {
            var exerciseGuid = Guid.Parse("{dda005cf-297d-450c-ae57-f65be5adebe7}");
            context.Exercise.Add(new ExerciseEntity
            {
                Id = exerciseGuid,
            });

            context.SaveChanges();
        }
    }
}
