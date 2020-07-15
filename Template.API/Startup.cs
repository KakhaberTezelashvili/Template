using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.API.Filters;
using Template.Application.Commands;
using Template.Domain.Repositories;
using Template.Infrastructure.Repositories;

namespace Template.API
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
            services.AddControllers(options =>
            {
                options.Filters.Add<ModelStateFilter>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddFluentValidation();
            
            services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();

            var assembly = AppDomain.CurrentDomain.Load("Template.Application");
            services.AddMediatR(assembly);

            services.AddScoped<IOrderRepository>(options =>
            {
                return new OrderRepository(@"Server=localhost\SQLEXPRESS;Database=TemplateDB;Trusted_Connection=True;");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}