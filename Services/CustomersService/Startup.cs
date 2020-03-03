using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApiHelpers.Formatters;
using CustomersService.Contexts;
using CustomersService.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CustomersService.Entities;
using CustomersBusiness.Models;

namespace CustomersService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(cfg =>
            {
                cfg.InputFormatters.Add(new ProtobufInputFormatter());
                cfg.OutputFormatters.Add(new ProtobufOutputFormatter());
            });
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<CustomerDbContext>(o => o.UseMySQL(connectionString));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if it is production, just return general server error message
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("A server error occured.");
                });
            });

            app.UseMvc();

            var customerContext = app.ApplicationServices.GetService<CustomerDbContext>();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
               
            });
        }
    }
}
