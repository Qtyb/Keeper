using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Common.Framework.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureCommonSwagger(this IServiceCollection services, string serviceName, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = serviceName, Version = version });
            });
        }

        public static void UseCommonSwagger(this IApplicationBuilder app, string serviceName, string version)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serviceName} {version}");
            });
        }
    }
}