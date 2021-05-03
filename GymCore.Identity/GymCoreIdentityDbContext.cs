using System;
using GymCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Identity
{
    public class GymCoreIdentityDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
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
