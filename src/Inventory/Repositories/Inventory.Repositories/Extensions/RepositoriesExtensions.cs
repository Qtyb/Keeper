using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void ConfigureInventoryRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromCallingAssembly()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}