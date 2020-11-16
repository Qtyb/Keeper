using Microsoft.Extensions.DependencyInjection;

namespace Places.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigurePlacesServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromCallingAssembly()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}