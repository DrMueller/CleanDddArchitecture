using System;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.DbContexts.Factories;
using Xunit;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingInfrastructure.Fixtures
{
    public abstract class IntegrationTestBase : IClassFixture<IntegrationTestFixture>
    {
        private readonly IntegrationTestFixture _fixture;

        protected IntegrationTestBase(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            var dbContextFactory = (InMemoryAppDbContextFactory)fixture.ServiceProvider.GetRequiredService<IAppDbContextFactory>();
            dbContextFactory.InitializeName();
        }

        protected IServiceProvider ServiceProvider => _fixture.ServiceProvider;
    }
}