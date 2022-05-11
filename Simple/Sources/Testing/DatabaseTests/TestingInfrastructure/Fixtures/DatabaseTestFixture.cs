using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using Lamar;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts.Implementation;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories.Implementation;
using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services;
using Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection;
using Xunit;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Fixtures
{
    [UsedImplicitly]
    public class DatabaseTestFixture : IAsyncLifetime
    {
        private string? _dockerContainerId;

        internal IContainer LamarContainer { get; private set; } = null!;

        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(_dockerContainerId))
            {
                var dockerContainerRemover = LamarContainer.GetInstance<IContainerRemover>();
                await dockerContainerRemover.RemoveContainerAsync(_dockerContainerId);
            }

            LamarContainer.Dispose();
        }

        public async Task InitializeAsync()
        {
            LamarContainer = TestContainerFactory.Create();

            await StartDockerContainerAsync();
            await WaitForDatabaseAsync();
            await MigrateDatabaseAsync();
        }

        private async Task MigrateDatabaseAsync()
        {
            var appDbContextFactory = LamarContainer.GetInstance<IAppDbContextFactory>();
            appDbContextFactory.Should().BeOfType<AppDbContextFactory>("WARNING: wrong dbcontext-factory (non-SQL) provided for db tests. Check DI.");

            var appDbContext = appDbContextFactory.Create();
            var dispoContext = (AppDbContext)appDbContext;
            await dispoContext.Database.MigrateAsync();
        }

        private async Task StartDockerContainerAsync()
        {
            var dockerContainerStarter = LamarContainer.GetInstance<IContainerStarter>();
            _dockerContainerId = await dockerContainerStarter.StartContainerAsync();
        }

        private async Task WaitForDatabaseAsync()
        {
            var dockerContainerAwaiter = LamarContainer.GetInstance<IContainerAwaiter>();
            await dockerContainerAwaiter.WaitUntilDataseAvailableAsync();
        }
    }
}