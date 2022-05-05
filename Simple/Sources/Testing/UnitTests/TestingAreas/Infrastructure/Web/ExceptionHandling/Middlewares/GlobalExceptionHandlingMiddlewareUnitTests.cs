using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Logging;
using Mmu.CleanDddSimple.Infrastructure.Web.ExceptionHandling.Middlewares;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Infrastructure.Web.ExceptionHandling.Middlewares
{
    public class GlobalExceptionHandlingMiddlewareUnitTests
    {
        private readonly Mock<ILoggingService> _loggerMock;

        public GlobalExceptionHandlingMiddlewareUnitTests()
        {
            _loggerMock = new Mock<ILoggingService>();
        }

        [Fact]
        public async Task Invoking_ActionThrowingException_CreatesErrorResponse()
        {
            // Arrange
            var ex = new ArgumentException("Tra");
            var req = new RequestDelegate(_ => throw ex);
            var contextMock = new DefaultHttpContext();
            var sut = CreateSut(req);

            // Act
            await sut.Invoke(contextMock);

            // Assert
            contextMock.Response.ContentType.Should().Be(MediaTypeNames.Application.Json);
            contextMock.Response.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);

            // Responsebody cant be tested, as it is a null stream
        }

        [Fact]
        public async Task Invoking_ActionThrowingException_ThrowsException()
        {
            // Arrange
            var ex = new ArgumentException("Tra");
            var req = new RequestDelegate(_ => throw ex);
            var contextMock = new DefaultHttpContext();
            var sut = CreateSut(req);

            // Act
            await sut.Invoke(contextMock);

            // Assert
            _loggerMock.Verify(f => f.LogException(ex), Times.Once);
        }

        [Fact]
        public async Task Invoking_ActionWorking_DoesNotLog()
        {
            // Arrange
            var req = new RequestDelegate(_ => Task.CompletedTask);
            var contextMock = new DefaultHttpContext();
            var sut = CreateSut(req);

            // Act
            await sut.Invoke(contextMock);

            // Assert
            _loggerMock.Verify(f => f.LogException(It.IsAny<Exception>()), Times.Never);
        }

        private GlobalExceptionHandlingMiddleware CreateSut(RequestDelegate req)
        {
            return new GlobalExceptionHandlingMiddleware(req, _loggerMock.Object);
        }
    }
}