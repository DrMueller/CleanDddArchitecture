using AutoMoqCore;
using FluentAssertions;
using Mmu.CleanDddSimple.Areas.Domain.Repositories;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks.Implementation;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.UnitOfWorks.Servants;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Infrastructure.DataAccess.UnitOfWorks
{
    public class UnitOfWorkUnitTests
    {
        private readonly UnitOfWork _sut;
        private readonly Mock<IRepositoryCache> _repoCacheMock;

        public UnitOfWorkUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<UnitOfWork>();
            _repoCacheMock = moqer.GetMock<IRepositoryCache>();
            var dbContextMock = new Mock<IAppDbContext>();
            _sut.Initialize(dbContextMock.Object);
        }

        [Fact]
        public void GettingRepository_GetsRepository()
        {
            // Arrange
            var meetingRepo = Mock.Of<IMeetingRepository>();
            _repoCacheMock.Setup(
                    f => f.GetRepository<IMeetingRepository>(
                        It.IsAny<IAppDbContext>()))
                .Returns(meetingRepo);

            // Act
            var actualRepo = _sut.GetRepository<IMeetingRepository>();

            // Assert
            actualRepo.Should().NotBeNull();
            actualRepo.Should().Be(meetingRepo);
        }
    }
}