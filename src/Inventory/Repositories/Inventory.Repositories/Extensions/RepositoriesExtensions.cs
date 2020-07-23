using Inventory.Repositories.Query;
using Inventory.Repositories.Query.Intefaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void ConfigureInventoryRepositories(this IServiceCollection services)
        {
            services.AddTransient<IThingQueryRepository, ThingQueryRepository>();
        }
    }
}