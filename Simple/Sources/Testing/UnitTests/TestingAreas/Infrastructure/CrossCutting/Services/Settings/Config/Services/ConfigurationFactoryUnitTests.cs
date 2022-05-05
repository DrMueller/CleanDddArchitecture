using FluentAssertions;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Services.Settings.Config.Services;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Infrastructure.CrossCutting.Services.Settings.Config.Services
{
    public class ConfigurationFactoryUnitTests
    {
        [Fact]
        public void Creating_Works()
        {
            // Act
            var actualConfig = ConfigurationFactory.Create();

            // Assert
            actualConfig.Should().NotBeNull();
        }
    }
}