using System.Linq;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories.Base;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.Infrastructure.DataAccess.Repositories
{
    public class RepositoryMock : RepositoryBase<IMeeting, Meeting>
    {
        public bool IncludesWereInitialized { get; private set; }

        protected override IQueryable<Meeting> InitializeIncludes(IQueryable<Meeting> query)
        {
            IncludesWereInitialized = true;

            return query;
        }
    }
}