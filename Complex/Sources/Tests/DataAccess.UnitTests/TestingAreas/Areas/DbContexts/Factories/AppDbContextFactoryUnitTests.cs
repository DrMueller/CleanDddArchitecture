using System;
using AutoMoqCore;
using FluentAssertions;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Models;
using Mmu.CleanDdd.CrossCutting.Areas.Settings.Provisioning.Services;
using Mmu.CleanDdd.DataAccess.Areas.DbContexts.Factories.Implementation;
using Xunit;

namespace Mmu.CleanDdd.DataAccess.UnitTests.TestingAreas.Areas.DbContexts.Factories
{
    public class AppDbContextFactoryUnitTests
    {
        private readonly AppDbContextFactory _sut;

        public AppDbContextFactoryUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<AppDbContextFactory>();

            moqer
                .GetMock<IAppSettingsProvider>()
                .Setup(f => f.Settings)
                .Returns(
                    new AppSettings
                    {
                        ConnectionString = "test1234"
                    });
        }

        [Fact]
        public void Creating_Works()
        {
            // Arrange
            Action act = () => _sut.Create();

            // Act & Assert
            act.Should().NotThrow();
        }
    }
}