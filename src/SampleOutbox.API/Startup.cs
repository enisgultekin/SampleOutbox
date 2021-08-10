using System;
using System.Linq;
using Autofac;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleOutbox.API.Configuration;
using SampleOutbox.API.SeedWork;
using SampleOutbox.Application.Configuration;
using SampleOutbox.Application.Configuration.Emails;
using SampleOutbox.Application.Configuration.Validation;
using SampleOutbox.Domain.SeedWork;
using SampleOutbox.Infrastructure;
using SampleOutbox.Infrastructure.Caching;

namespace SampleOutbox.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private const string OrdersConnectionString = "OrdersConnectionString";
        private static ILogger _logger;

        public Startup(IWebHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();
            services.AddSwaggerDocumentation();

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });

            services.AddHttpContextAccessor();
            
            var children = this._configuration.GetSection("Caching").GetChildren();
            var cachingConfiguration = children.ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));

            services.AddSingleton(x=>new MemoryCacheStore(x.GetService<IMemoryCache>()!, cachingConfiguration));
            services.AddSingleton<IExecutionContextAccessor>(x =>
                new ExecutionContextAccessor(x.GetService<IHttpContextAccessor>()));

        }

        public void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();

            ApplicationStartup.Initialize(builder, 
                _configuration[OrdersConnectionString],
                null, 
                emailSettings, 
                _logger);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CorrelationMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO : ProblemDetails
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwaggerDocumentation();
        }
    }
}