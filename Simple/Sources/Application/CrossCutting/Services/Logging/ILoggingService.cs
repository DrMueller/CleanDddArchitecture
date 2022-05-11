using System;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.CrossCutting.Services.Logging
{
    [PublicAPI]
    public interface ILoggingService
    {
        void LogError(string message);

        void LogException(Exception ex);

        void LogInformation(string message);
    }
}