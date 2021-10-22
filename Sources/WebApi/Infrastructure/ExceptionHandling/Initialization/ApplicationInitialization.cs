using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.WebApi.Infrastructure.ExceptionHandling.Middlewares;

namespace Mmu.CleanDdd.WebApi.Infrastructure.ExceptionHandling.Initialization
{
    [PublicAPI]
    public static class ApplicationInitialization
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            Guard.ObjectNotNull(() => app);
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            return app;
        }
    }
}