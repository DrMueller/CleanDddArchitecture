using AutoMoqCore;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services.Implementation;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Infrastructure.CrossCutting.Services.Settings.Provisioning.Services
{
    public class AppSettingsProviderUnitTests
    {
        private readonly AutoMoqer _moqer;
        private readonly AppSettingsProvider _sut;

        public AppSettingsProviderUnitTests()
        {
            _moqer = new AutoMoqer();
            _sut = _moqer.Create<AppSettingsProvider>();
        }

        [Fact]
        public void ProvidingSettings_ProvidesSettings()
        {
            // Arrange
            var settings = new AppSettings();
            _moqer
                .GetMock<IOptions<AppSettings>>()
                .Setup(f => f.Value)
                .Returns(settings);

            // Act
            var actualSettings = _sut.Settings;

            // Assert
            actualSettings.Should().Be(settings);
        }
    }
}