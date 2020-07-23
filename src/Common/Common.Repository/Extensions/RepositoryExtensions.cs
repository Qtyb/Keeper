using Common.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureCommonRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}