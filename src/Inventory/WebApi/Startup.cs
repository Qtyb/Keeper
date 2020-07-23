using Common.Framework.Extensions;
using Common.Logging.Extensions;
using Inventory.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inventory
{
    public class Startup
    {
        private readonly string _version = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<InventoryContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("InventoryContext")));

            services.ConfigureCommonSwagger(nameof(Inventory), _version);
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
                app.UseCommonExceptionHandler();
            }

            //app.UseHttpsRedirection();

            app.UseCommonRequestLogging();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCommonSwagger(nameof(Inventory), _version);
        }
    }
}