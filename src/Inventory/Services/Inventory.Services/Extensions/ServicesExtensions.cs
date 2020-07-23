using Inventory.Services.Mappings;
using Inventory.Services.Mappings.Interfaces;
using Inventory.Services.Query;
using Inventory.Services.Query.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureInventoryServices(this IServiceCollection services)
        {
            services.AddTransient<IThingMappingService, ThingMappingService>();
            services.AddTransient<IThingQueryService, ThingQueryService>();
        }
    }
}