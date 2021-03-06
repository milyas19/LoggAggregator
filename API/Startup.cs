using Application;
using Application.Create;
using AutoMapper;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Data;
using Persistence.Data.DBWrapper;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDBWrapper<LoggAggregator>, LoggAggregatorDBWrapper>();

            services.AddDbContext<LoggAggregatorContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(CreateLogCommandHandler).GetTypeInfo().Assembly);

            services.AddCors();

            services.AddHealthChecks();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddAutoMapper(typeof(LogProfile));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Log Aggregator API",
                    Version = "v1",
                    Description = ""
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/Swagger/v1/swagger.json", "Log Aggregator API");
                s.RoutePrefix = "swagger/ui";
            });

            app.UseCors(
                 options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
