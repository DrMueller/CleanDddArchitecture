using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Mmu.Cca.WebApi.Infrastructure.ExceptionHandling.Middlewares;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;

namespace Mmu.Cca.WebApi.Infrastructure.ExceptionHandling.Initialization
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