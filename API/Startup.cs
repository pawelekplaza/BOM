using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inftastructure.Mappers;
using Inftastructure.Services;
using Inftastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace API
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
            services.AddMvc();
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BOM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                    b => b.MigrationsAssembly("API"));
            });

            services.AddScoped<IBomService, BomService>();
            services.AddSingleton(AutoMapperConfig.Initialize());            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config =>
            {
                config.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });
            app.UseMvc();            
        }
    }
}
