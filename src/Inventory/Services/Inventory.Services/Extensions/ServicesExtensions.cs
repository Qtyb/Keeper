using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureInventoryServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromCallingAssembly()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}