using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Mmu.CleanDddSimple.Web.Infrastructure.ExceptionHandling.Middlewares;

namespace Mmu.CleanDddSimple.Web.Infrastructure.ExceptionHandling.Initialization
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