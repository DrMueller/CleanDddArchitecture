using AutoMoqCore;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.CleanDddSimple.CrossCutting.Services.Settings.Provisioning.Services;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.DataAccess.DbContexts.Factories
{
    public class AppDbContextFactoryUnitTests
    {
        private readonly AppDbContextFactory _sut;
        private readonly Mock<IDbContextOptionsFactory> _optionsFactoryMock;
        private readonly Mock<IAppSettingsProvider> _appSettingsProviderMock;

        public AppDbContextFactoryUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<AppDbContextFactory>();
            _optionsFactoryMock = moqer.GetMock<IDbContextOptionsFactory>();
            _appSettingsProviderMock = moqer.GetMock<IAppSettingsProvider>();

            _optionsFactoryMock.Setup(
                    f => f.CreateForSqlServer(
                        It.IsAny<string>()))
                .Returns(new DbContextOptionsBuilder().Options);
        }

        [Fact]
        public void Creating_CreatesOptions_WithConnectionString()
        {
            // Arrange
            const string ConnectionString = "Test12345";
            _appSettingsProviderMock
                .Setup(f => f.Settings)
                .Returns(
                    new AppSettings
                    {
                        ConnectionString = ConnectionString
                    });

            // Act
            _sut.Create();

            // Assert
            _optionsFactoryMock
                .Verify(f => f.CreateForSqlServer(ConnectionString), Times.Once);
        }

        [Fact]
        public void Creating_MultipleTmes_CreatesOptionsOnce()
        {
            // Arrange
            _appSettingsProviderMock
                .Setup(f => f.Settings)
                .Returns(
                    new AppSettings
                    {
                        ConnectionString = "Tra1234"
                    });

            // Act
            _sut.Create();
            _sut.Create();

            // Assert
            _optionsFactoryMock
                .Verify(f => f.CreateForSqlServer(It.IsAny<string>()), Times.Once);
        }
    }
}