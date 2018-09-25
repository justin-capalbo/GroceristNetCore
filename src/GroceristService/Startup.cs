using GroceristLibrary.ApplicationLogic;
using GroceristLibrary.DB;
using GroceristLibrary.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace GroceristService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GroceristContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("GroceristService"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("OpenPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            }); 

            services.AddMvc();
            services.AddTransient<IGroceristRepository, GroceristRepository>();
            services.AddTransient<IGroceristMapper, GroceristMapper>();
            services.AddTransient<IListApplicationLogic, ListApplicationLogic>();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info() {Title = "Grocerist API", Version = "v1" }); });
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
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCors("OpenPolicy");

            app.UsePathBase("/grocerist-service");

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grocerist API V1"); });
            app.UseMvc();
        }
    }
}
