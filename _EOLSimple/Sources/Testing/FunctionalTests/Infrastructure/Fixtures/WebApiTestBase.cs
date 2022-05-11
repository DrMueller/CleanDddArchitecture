using System.Net.Http;
using System.Threading.Tasks;
using LightBDD.XUnit2;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.FunctionalTests.Infrastructure.ApiCommunication.Models;
using Mmu.CleanDddSimple.FunctionalTests.Infrastructure.ApiCommunication.Services;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregateLoading;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregatePersisting;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.DbContexts.Factories;
using Xunit;

namespace Mmu.CleanDddSimple.FunctionalTests.Infrastructure.Fixtures
{
    [Collection(WebApiCollectionFixture.CollectionName)]
    public abstract class WebApiTestBase : FeatureFixture
    {
        private readonly WebApiTestFixture _fixture;

        // This happens once per test-method, so every test gets a new InMemory DB with a distinct name
        protected WebApiTestBase(WebApiTestFixture fixture)
        {
            _fixture = fixture;

            // This works because the collection runs tests one after another and the factory is a singleton, so we can be sure to not mix stuff up
            var dbContextFactory = (InMemoryAppDbContextFactory)_fixture.AppFactory.Services.GetRequiredService<IAppDbContextFactory>();
            dbContextFactory.InitializeName();
        }

        protected IAggregateLoader AggregateLoader => _fixture.AppFactory.Services.GetRequiredService<IAggregateLoader>();
        protected IAggregatePersister AggregatePersister => _fixture.AppFactory.Services.GetRequiredService<IAggregatePersister>();

        protected async Task<ApiResult> SendAsync(
            HttpMethod method,
            string relativeUrl,
            object? body = null)
        {
            var apiSender = _fixture.AppFactory.Services.GetRequiredService<IApiSender>();

            return await apiSender.SendAsync(_fixture.AppFactory.CreateClient(), method, relativeUrl, body);
        }
    }
}