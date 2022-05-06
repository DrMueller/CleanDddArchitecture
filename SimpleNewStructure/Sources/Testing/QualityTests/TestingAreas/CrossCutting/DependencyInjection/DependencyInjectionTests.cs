using FluentAssertions;
using Lamar;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures;
using Mmu.CleanDddSimple.Web.Areas.Controllers;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.CrossCutting.DependencyInjection
{
    public class DependencyInjectionTests : QualityTestBase
    {
        public DependencyInjectionTests(QualityTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public void LamarConfiguration_IsValid()
        {
            var serviceContainer = AppFactory.Services;
            serviceContainer.Should().BeOfType<Container>();
            var container = (IContainer)serviceContainer;
            var testService = container.GetInstance<MeetingsController>();

            testService.Should().NotBeNull();
            container.AssertConfigurationIsValid();
        }
    }
}