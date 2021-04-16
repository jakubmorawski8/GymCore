﻿using GymCore.Infrastructure;
using GymCore.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GymCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var csCoreDb = Configuration.GetConnectionString("GymCoreDBContext");
            var csIdentityDb = Configuration.GetConnectionString("GymCoreIdentityDbContext");

            services.AddDbContext<GymCoreDBContext>(csCoreDb);
            services.AddDbContext<GymCoreIdentityDbContext>(csIdentityDb);

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<GymCoreDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
