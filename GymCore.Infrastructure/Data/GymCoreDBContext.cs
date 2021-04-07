using Microsoft.EntityFrameworkCore;

namespace GymCore.Infrastructure.Data
{
    public class GymCoreDBContext : DbContext
    {
        public GymCoreDBContext(DbContextOptions<GymCoreDBContext> options) : base(options)
        {

        }


    }
}
