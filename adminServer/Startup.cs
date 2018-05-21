using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adminServer.Domain.Implementation;
using adminServer.Domain.Interfaces;
using adminServer.Domain.Persistence;
using adminServer.Services.Implementation;
using adminServer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace adminServer
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
            services.AddCors();
            services.AddMvc();
            string connectionString = Environment.GetEnvironmentVariable("connectionString");
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, Repository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ApplicationContext>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:9292"));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
