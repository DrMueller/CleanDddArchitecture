using System;
using Microsoft.Extensions.Logging;

namespace Mmu.CleanDddSimple.CrossCutting.Services.Logging.Implementation
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogError(string message)
        {
            Console.WriteLine("Error: " + message);
            _logger.LogError(message);
        }

        public void LogException(Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            _logger.LogError(ex, ex.Message);
        }

        public void LogInformation(string message)
        {
            Console.WriteLine("Information: " + message);
            _logger.LogInformation(message);
        }
    }
}