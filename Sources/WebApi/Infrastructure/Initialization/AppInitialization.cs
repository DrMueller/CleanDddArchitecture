using Microsoft.AspNetCore.Builder;
using Mmu.Cca.WebApi.Infrastructure.ExceptionHandling.Initialization;

namespace Mmu.Cca.WebApi.Infrastructure.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(IApplicationBuilder app)
        {
            app.UseGlobalExceptionHandler();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(
                config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture API");
                });

            app.UseCors("All");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}