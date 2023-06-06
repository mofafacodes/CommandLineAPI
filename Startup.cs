using AutoMapper;
using CommandLineAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace CommandLineAPI
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
            //dbcontext class configuration to be used in entire application
            //NOTE- if you are using a database provider
            //you use a different package reference within your csproj file
            //you use different format of connections strings
            //in here you'll use  a different syntax for database class instantiation
            services.AddDbContext<CommandLineContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CommandLineConnection")));

           

            services.AddControllers().AddNewtonsoftJson(s => 
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });


            //adding automapper to map our internal domain commands to the various DTOs, making availvable throught out the application
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());   

            // services.AddScoped<ICommandLineRepo, MockCommandLineRepo>();
            services.AddScoped<ICommandLineRepo, SqlCommandLineRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //includes mainly middlewares
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
