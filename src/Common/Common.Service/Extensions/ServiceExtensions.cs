using Common.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IHttpContextUserService, HttpContextUserService>();
        }
    }
}