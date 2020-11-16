using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Places.Data.Extensions
{
    public static class DataExtensions
    {
        public static void ConfigurePlacesData(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, PlacesContext>();
        }
    }
}