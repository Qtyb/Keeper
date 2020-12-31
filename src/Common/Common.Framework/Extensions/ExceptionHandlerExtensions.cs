using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Common.Framework.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseCommonExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    await context.Response.WriteAsync("Unknown error");
                });
            });
        }
    }
}