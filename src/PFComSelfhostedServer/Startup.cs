using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PFComSelfhostedServer.Services;
using PFComSelfhostedServer.Services.Users;
using PFComSelfhostedServer.Services.Users.Sessions;
using PFComSelfhostedServer.Services.Users.Sessions.LocalSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFComSelfhostedServer
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PFComSelfhostedServer", Version = "v1" });
            });

            services.AddDbContextPool<Data.Database.DataContext>(
                x => x.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))
                    ));

            services.AddScoped<UserRegisterer>();
            services.AddSingleton<PasswordHashService>();
            services.AddSingleton<PasswordComparator>();
            services.AddScoped<UserLoginer>();
            services.AddScoped<LocalSessionRegisterer>();
            services.AddScoped<LocalSessionRegisterer>();
            services.AddScoped<SessionValidator>();
            services.AddScoped<UserNameValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "PFComSelfhostedServer v1"));
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
