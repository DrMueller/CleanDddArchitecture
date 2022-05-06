using System.Diagnostics.CodeAnalysis;
using Mmu.CleanDddSimple.DataAccess.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Moq;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.Mocks
{
    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Same Naming as in Moq")]
    public class UnitOfWorkFactoryMock
    {
        private readonly Mock<IUnitOfWorkFactory> _uowFactoryMock;

        public UnitOfWorkFactoryMock()
        {
            _uowFactoryMock = new Mock<IUnitOfWorkFactory>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            _uowFactoryMock.Setup(f => f.Create()).Returns(UnitOfWorkMock.Object);
        }

        public IUnitOfWorkFactory Object => _uowFactoryMock.Object;
        public Mock<IUnitOfWork> UnitOfWorkMock { get; }

        public Mock<T> RegisterRepositoryMock<T>()
            where T : class, IRepository
        {
            var mock = new Mock<T>();
            UnitOfWorkMock.Setup(f => f.GetRepository<T>()).Returns(mock.Object);

            return mock;
        }
    }
}