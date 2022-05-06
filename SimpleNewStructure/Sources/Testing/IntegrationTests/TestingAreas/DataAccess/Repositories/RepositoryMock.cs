using System.Linq;
using Mmu.CleanDddSimple.DataAccess.Repositories.Implementation.Base;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.Repositories
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