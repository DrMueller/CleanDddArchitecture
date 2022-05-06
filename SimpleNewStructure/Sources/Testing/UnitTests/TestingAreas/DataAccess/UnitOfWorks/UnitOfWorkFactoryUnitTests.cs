using AutoMoqCore;
using FluentAssertions;
using Lamar;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Implementation;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Servants;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.DataAccess.UnitOfWorks
{
    public class UnitOfWorkFactoryUnitTests
    {
        private readonly UnitOfWorkFactory _sut;
        private readonly Mock<IAppDbContextFactory> _dbContextFactoryMock;
        private readonly Mock<IContainer> _containerMock;

        public UnitOfWorkFactoryUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<UnitOfWorkFactory>();
            _dbContextFactoryMock = moqer.GetMock<IAppDbContextFactory>();
            _containerMock = moqer.GetMock<IContainer>();

            _dbContextFactoryMock
                .Setup(f => f.Create())
                .Returns(Mock.Of<IAppDbContext>());

            _containerMock
                .Setup(f => f.GetInstance<UnitOfWork>())
                .Returns(new UnitOfWork(Mock.Of<IRepositoryCache>()));
        }

        [Fact]
        public void Creating_CreatesDbContext()
        {
            // Act
            _sut.Create();

            // Assert
            _dbContextFactoryMock.Verify(f => f.Create(), Times.Once);
        }

        [Fact]
        public void Creating_ResolvesUnitOfWork()
        {
            // Act
            _sut.Create();

            // Assert
            _containerMock.Verify(f => f.GetInstance<UnitOfWork>(), Times.Once);
        }

        [Fact]
        public void Creating_Works()
        {
            // Arrange
            var act = () => _sut.Create();

            // Act & Assert
            act.Should().NotThrow();
        }
    }
}