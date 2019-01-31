using AutoMapper;
using CqrsSample.Data;
using CqrsSample.Infrastructure.Extensions;
using CqrsSample.Infrastructure.Automapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Utils;
using MediatR;


namespace CqrsSample
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
            var commandsConnectionString = new CommandsConnectionString(Configuration.GetConnectionString("CommandConnectionString"));
            var queriesConnectionString = new QueriesConnectionString(Configuration.GetConnectionString("QueriesConnectionString"));

            services.AddSingleton(commandsConnectionString);
            services.AddSingleton(queriesConnectionString);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            
            
            services.AddDbContext<StudentContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("CommandConnectionString"));
            });

            services.AddApiVersioning();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Student Management System",
                    Version = "v1",
                    Description = "API for Student Management System"
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            services.AddMediatR(typeof(Startup).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.ConfigureCustomExceptionMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Student Management System API v1"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
