using GymCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Infrastructure.Data
{
    public class GymCoreIdentityDbContext : IdentityDbContext<UserEntity, IdentityRole<long>, long>
    {
        private readonly DbContextOptions _options;

        public GymCoreIdentityDbContext(DbContextOptions<GymCoreIdentityDbContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
