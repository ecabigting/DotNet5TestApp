using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Web.Models.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Startup
    {
        IWebHostEnvironment _env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var seriLogger = new LoggerConfiguration()
                .WriteTo.File(_env.WebRootPath + @"\Logs\logs.text")
                .CreateLogger();

            services.AddLogging(builder => {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddSerilog(logger: seriLogger, dispose: true);
            });

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDB_InMemory"));

            // Add Kestrel as server option
            services.Configure<KestrelServerOptions>(
            Configuration.GetSection("Kestrel"));

            // Add the views of the web app
            services.AddControllersWithViews();
            // Add the controllers for the API
            services.AddControllers();

            // Enable MVC for the web app
            services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation();
            services.AddMvc().AddNewtonsoftJson();

            // Add validators
            services.AddTransient<IValidator<Employee>, EmployeeValidator>();

            // Add swagger
            services.AddSwaggerGen();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn Application v1.0");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
