using Common.EventBus.Extensions;
using Common.EventBus.Interfaces;
using Common.Framework.Extensions;
using Common.Logging.Extensions;
using Common.Repository.Extensions;
using Common.Service.Extensions;
using Inventory.Data;
using Inventory.Data.Extensions;
using Inventory.Models.Events.Places;
using Inventory.Models.Events.Users;
using Inventory.Repositories.Extensions;
using Inventory.Services.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Security.Claims;

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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<InventoryContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("InventoryContext")));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                //Move to appsettings
                o.Authority = "http://localhost:7200";
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                //Policies - example of use
                //For proper implemention this needs to be used inside Authorize annotations
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });

            services.ConfigureInventoryData();
            services.ConfigureCommonRepositories();
            services.ConfigureInventoryRepositories();
            services.ConfigureCommonServices();
            services.ConfigureInventoryServices();
            services.ConfigureCommonSwagger(nameof(Inventory), _version);

            services.AddEventBus();
        }

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
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCommonSwagger(nameof(Inventory), _version);
            SetupEventBus(app);
        }

        private static void SetupEventBus(IApplicationBuilder app)
        {
            var subsriberService = app.ApplicationServices.GetRequiredService<IEventBusSubscriber>();
            subsriberService.SetupSubscriber();
            subsriberService.Subscribe<PlaceCreatedEvent>();
            subsriberService.Subscribe<PlaceUpdatedEvent>();
            subsriberService.Subscribe<PlaceDeletedEvent>();
            subsriberService.Subscribe<UserCreatedEvent>();
        }
    }
}