using System;
using System.Transactions;
using Mmu.CleanDddSimple.Testing.Common.Areas.DataAccess.AggregateLoading;
using Xunit;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Fixtures
{
    [Collection(DatabaseCollectionFixture.CollectionName)]
    public abstract class DatabaseTestBase : IDisposable
    {
        private readonly DatabaseTestFixture _fixture;
        private readonly TransactionScope _scope;

        protected DatabaseTestBase(DatabaseTestFixture fixture)
        {
            _fixture = fixture;
            _scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        protected IAggregateLoader AggregateLoader => _fixture.LamarContainer.GetInstance<IAggregateLoader>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _scope.Dispose();
            }
        }
    }
}