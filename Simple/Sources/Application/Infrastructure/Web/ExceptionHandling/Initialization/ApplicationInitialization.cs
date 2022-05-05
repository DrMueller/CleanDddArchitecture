using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Mmu.CleanDddSimple.Infrastructure.Web.ExceptionHandling.Middlewares;

namespace Mmu.CleanDddSimple.Infrastructure.Web.ExceptionHandling.Initialization
{
    [PublicAPI]
    public static class ApplicationInitialization
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            return app;
        }
    }
}