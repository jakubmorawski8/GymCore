using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
