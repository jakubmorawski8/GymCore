using System;
using GymCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace GymCore.Persistence.IntegrationTests
{
    public class GymCoreDbContextTests
    {
        private readonly GymCoreDbContext _gymCoreDbContext;

        public GymCoreDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GymCoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _gymCoreDbContext = new GymCoreDbContext(dbContextOptions);
        }

        [Fact]
        public async void SaveEntityShouldGenerateId()
        {
            var exercise = new ExerciseEntity() { Name = "Test", Description = "Desc" };

            _gymCoreDbContext.Exercise.Add(exercise);
            await _gymCoreDbContext.SaveChangesAsync();

            exercise.Id.ShouldBeOfType<Guid>();
            exercise.Id.ToString().ShouldNotBeEmpty();
        }
    }
}
