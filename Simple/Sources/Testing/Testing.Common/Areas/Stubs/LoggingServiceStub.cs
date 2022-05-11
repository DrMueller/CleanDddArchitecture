using System;
using Mmu.CleanDddSimple.CrossCutting.Services.Logging;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.Stubs
{
    public class LoggingServiceStub : ILoggingService
    {
        public void LogError(string message)
        {
        }

        public void LogException(Exception ex)
        {
        }

        public void LogInformation(string message)
        {
        }
    }
}