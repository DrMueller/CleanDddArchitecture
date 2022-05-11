using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.Infrastructure.Web.Security;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.Infrastructure.Web.Security
{
    // Taken from https://stackoverflow.com/questions/58963133/unit-test-custom-authenticationhandler-middleware
    public class BasicAuthenticationIntTests
    {
        private readonly BasicAuthenticationHandler _sut;
        private readonly SecuritySettings _securitySettings;

        public BasicAuthenticationIntTests()
        {
            var options = new Mock<IOptionsMonitor<AuthenticationSchemeOptions>>();

            options
                .Setup(x => x.Get(It.IsAny<string>()))
                .Returns(new AuthenticationSchemeOptions());

            var logger = new Mock<ILogger<BasicAuthenticationHandler>>();
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(logger.Object);

            var encoder = new Mock<UrlEncoder>();
            var clock = new Mock<ISystemClock>();
            var appSettingsProvider = new Mock<IAppSettingsProvider>();

            _securitySettings = new SecuritySettings
            {
                Password = "Password4321",
                UserName = "UserName1234"
            };

            appSettingsProvider
                .Setup(f => f.Settings)
                .Returns(
                    new AppSettings
                    {
                        SecuritySettings = _securitySettings
                    });

            _sut = new BasicAuthenticationHandler(
                options.Object,
                loggerFactory.Object,
                encoder.Object,
                clock.Object,
                appSettingsProvider.Object);
        }

        [Fact]
        public async Task Authenticating_AuthorizationHeaderBeingCorrect_Works()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers.Authorization = "Tra";
            const string Str = "1234:4321";
            var encodedCredentials = Convert.ToBase64String(Encoding.Default.GetBytes(Str));
            context.Request.Headers.Authorization = $"Basic {encodedCredentials}";

            await _sut.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);

            // Act
            var result = await _sut.AuthenticateAsync();

            // Assert
            result.Succeeded.Should().BeFalse();
            result.Failure!.Message.Should().Be(BasicAuthenticationHandler.WrongCredentialsError);
        }

        [Fact]
        public async Task Authenticating_AuthorizationHeaderHavingWrongValues_ReturnsError()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers.Authorization = "Tra";
            var str = $"{_securitySettings.UserName}:{_securitySettings.Password}";
            var encodedCredentials = Convert.ToBase64String(Encoding.Default.GetBytes(str));
            context.Request.Headers.Authorization = $"Basic {encodedCredentials}";

            await _sut.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);

            // Act
            var result = await _sut.AuthenticateAsync();

            // Assert
            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task Authenticating_AuthorizationHeaderNotSet_ReturnsError()
        {
            // Arrange
            var context = new DefaultHttpContext();
            await _sut.InitializeAsync(new AuthenticationScheme(BasicAuthenticationHandler.SchemeName, null, typeof(BasicAuthenticationHandler)), context);

            // Act
            var result = await _sut.AuthenticateAsync();

            // Assert
            result.Succeeded.Should().BeFalse();
            result.Failure!.Message.Should().Be(BasicAuthenticationHandler.MissingHeaderError);
        }
    }
}