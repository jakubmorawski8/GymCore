using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymCore.Infrastructure.Data
{
    public class GymCoreIdentityDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public GymCoreIdentityDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
