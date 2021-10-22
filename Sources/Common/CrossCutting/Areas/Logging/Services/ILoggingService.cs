using System;

namespace Mmu.CleanDdd.CrossCutting.Areas.Logging.Services
{
    public interface ILoggingService
    {
        void LogError(string message);

        void LogException(Exception ex);

        void LogInformation(string message);

        void LogWarning(string warning);
    }
}