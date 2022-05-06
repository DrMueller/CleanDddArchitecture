using System.Linq;
using AutoMoqCore;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.DataAccess.DbContexts.Factories
{
    public class DbContextOptionsFactoryUnitTests
    {
        private readonly DbContextOptionsFactory _sut;

        public DbContextOptionsFactoryUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<DbContextOptionsFactory>();
        }

        [Fact]
        public void CreatingForSqlServer_CreatesSqlServerOptions()
        {
            // Act
            var actualOptions = _sut.CreateForSqlServer("Tra");

            // Assert
            actualOptions.Should().NotBeNull();

#pragma warning disable EF1001 // Internal EF Core API usage.
            var sqlExtType = typeof(SqlServerOptionsExtension);
#pragma warning restore EF1001 // Internal EF Core API usage.
            var sqlExtension = actualOptions.Extensions.SingleOrDefault(f => f.GetType() == sqlExtType);
            sqlExtension.Should().NotBeNull();
        }
    }
}