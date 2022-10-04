﻿using GymCore.API.Services;
using GymCore.Application;
using GymCore.Application.Interfaces;
using GymCore.Identity;
using GymCore.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GymCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApplicationServices();
            services.AddPersistenceServices(Configuration.GetConnectionString("GymCoreDbContext"));
            services.AddIdentityServices(Configuration.GetConnectionString("GymCoreIdentityDbContext"));

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<JwtManager>();

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2.2", new OpenApiInfo
                {
                    Version = "v2.2",
                    Title = "GymCoreAPI v2.2"
                });
            });
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors("Open");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2.2/swagger.json", "GymCoreAPI v2.2");
            });
        }
    }
}
