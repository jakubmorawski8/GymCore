using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

            //    services.AddEntityFrameworkNpgsql().AddDbContext<GymCoreDBContext>(opt =>
            //opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));

            services.AddEntityFrameworkNpgsql().AddDbContext<GymCoreDBContext>(opt =>
        opt.UseNpgsql("Host=localhost;Username=GymCoreAdmin;Persist Security Info=True;Password=SQL123;Database=GymCoreDB"));

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
