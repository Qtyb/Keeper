using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Common.Logging.Extensions
{
    public static class LoggerExtensions
    {
        public static void UseCommonRequestLogging(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }

        public static void UseCommonLogger(this IWebHostBuilder webBuilder)
        {
            webBuilder.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration);
            });
        }
    }
}