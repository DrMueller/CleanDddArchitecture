using System;
using AutoMoqCore;
using FluentAssertions;
using Lamar;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.DataAccess.Repositories.Implementation;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Servants.Implementation;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.DataAccess.UnitOfWorks.Servants
{
    public class RepositoryCacheUnitTests
    {
        private readonly RepositoryCache _sut;
        private readonly Mock<IAppDbContext> _dbContextMock;
        private readonly Mock<IContainer> _containerMock;

        public RepositoryCacheUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<RepositoryCache>();
            _dbContextMock = new Mock<IAppDbContext>();
            _containerMock = moqer.GetMock<IContainer>();
        }

        [Fact]
        public void GettingRepository_GetsRepository()
        {
            // Arrange
            _containerMock
                .Setup(f => f.GetInstance<IMeetingRepository>())
                .Returns(new MeetingRepository());

            // Act
            var actualRepo = _sut.GetRepository<IMeetingRepository>(_dbContextMock.Object);

            // Assert
            actualRepo.Should().NotBeNull();
        }

        [Fact]
        public void GettingRepository_MulitpleTimes_ResolvesRepositoryOnce()
        {
            // Arrange
            _containerMock
                .Setup(f => f.GetInstance<IMeetingRepository>())
                .Returns(new MeetingRepository());

            // Act
            _sut.GetRepository<IMeetingRepository>(_dbContextMock.Object);
            _sut.GetRepository<IMeetingRepository>(_dbContextMock.Object);

            // Assert
            _containerMock.Verify(f => f.GetInstance<IMeetingRepository>(), Times.Once);
        }

        [Fact]
        public void GettingRepository_RepositoryNotImplementingRepositoryBase_ThrowsArgumentException()
        {
            // Arrange
            _containerMock
                .Setup(f => f.GetInstance<IMeetingRepository>())
                .Returns(Mock.Of<IMeetingRepository>());

            var act = () => _sut.GetRepository<IMeetingRepository>(_dbContextMock.Object);

            // Act & Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GettingRepository_ResolvesRepository()
        {
            // Arrange
            _containerMock
                .Setup(f => f.GetInstance<IMeetingRepository>())
                .Returns(new MeetingRepository());

            // Act
            _sut.GetRepository<IMeetingRepository>(_dbContextMock.Object);

            // Assert
            _containerMock.Verify(f => f.GetInstance<IMeetingRepository>(), Times.Once);
        }
    }
}