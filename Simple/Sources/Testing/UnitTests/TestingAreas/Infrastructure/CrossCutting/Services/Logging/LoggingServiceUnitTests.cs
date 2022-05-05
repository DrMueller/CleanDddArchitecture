using System;
using AutoMoqCore;
using Microsoft.Extensions.Logging;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Logging.Implementation;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Infrastructure.CrossCutting.Services.Logging
{
    public class LoggingServiceUnitTests
    {
        private readonly LoggingService _sut;
        private readonly Mock<ILogger<LoggingService>> _loggerMock;

        public LoggingServiceUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<LoggingService>();
            _loggerMock = moqer.GetMock<ILogger<LoggingService>>();
        }

        [Fact]
        public void LogError_LogsError()
        {
            // Arrange
            const string Message = "Test123";

            // Act
            _sut.LogError(Message);

            // Assert
            _loggerMock.VerifyLog(f => f.LogError(Message));
        }

        [Fact]
        public void LogException_LogsException()
        {
            // Arrange
            var exception = new Exception("Tra12345");

            // Act
            _sut.LogException(exception);

            // Assert
            _loggerMock.VerifyLog(f => f.LogError(exception, exception.Message), Times.Once);
        }

        [Fact]
        public void LogInformation_LogsInformation()
        {
            // Arrange
            const string Message = "Test";

            // Act
            _sut.LogInformation(Message);

            // Assert
            _loggerMock.VerifyLog(f => f.LogInformation(Message), Times.Once);
        }
    }
}