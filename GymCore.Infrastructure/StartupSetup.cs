using GymCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymCore.Infrastructure
{
	public static class StartupSetup
	{
		public static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
			services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
				options.UseNpgsql(connectionString,
				x=>x.MigrationsAssembly("GymCore.Infrastructure"))
				);
		}
			 
	}
}
