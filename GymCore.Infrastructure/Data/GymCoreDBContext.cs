using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymCore.Infrastructure.Data
{
    public class GymCoreDBContext : DbContext
    {
        public GymCoreDBContext(DbContextOptions<GymCoreDBContext> options) : base(options) 
        {
            
        }

      
    }
}
