using FluentAssertions;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Config.Services;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.CrossCutting.Services.Settings.Config.Services
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