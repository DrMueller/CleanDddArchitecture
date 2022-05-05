using FluentAssertions;
using Lamar;
using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.Tests;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Areas.CrossCutting.DependencyInjection
{
    public class LamarConfigurationTests : WebAppTestBase
    {
        public LamarConfigurationTests(WebAppTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void LamarConfiguration_IsValid()
        {
            var serviceContainer = AppFactory.Services;
            serviceContainer.Should().BeOfType<Container>();
            var container = (IContainer)serviceContainer;

            container.AssertConfigurationIsValid();
        }
    }
}