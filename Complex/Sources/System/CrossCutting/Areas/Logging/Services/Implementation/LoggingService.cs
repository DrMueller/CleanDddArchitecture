using System;
using NLog;

namespace Mmu.CleanDdd.CrossCutting.Areas.Logging.Services.Implementation
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService()
        {
            _logger = LogManager.GetLogger(nameof(LoggingService));
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogException(Exception ex)
        {
            _logger.Error(ex, ex.Message);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string warning)
        {
            _logger.Warn(warning);
        }
    }
}