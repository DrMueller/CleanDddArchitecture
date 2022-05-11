using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.DataAccess
{
    public class TypeConfigurationTests : QualityTestBase
    {
        public TypeConfigurationTests(QualityTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public void TypeConfigurations_AreValid()
        {
            // Arrange
            var optionsFactory = AppFactory.Services.GetRequiredService<IDbContextOptionsFactory>();

            var connectionString = AppFactory
                .Services
                .GetRequiredService<IAppSettingsProvider>()
                .Settings.ConnectionString;

            var act = () => optionsFactory.CreateForSqlServer(connectionString);

            // Act & Assert
            // If it doesn't throw, we dont have a config error
            act.Should().NotThrow();
        }
    }
}