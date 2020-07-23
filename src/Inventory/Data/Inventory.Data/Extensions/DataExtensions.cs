using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Data.Extensions
{
    public static class DataExtensions
    {
        public static void ConfigureInventoryData(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, InventoryContext>();
        }
    }
}