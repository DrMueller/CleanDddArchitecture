using System.Linq;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.Infrastructure.DataAccess.Querying
{
    public class EntitySpecMock : IQuerySpecification<Meeting>
    {
        public bool SpecWasApplied { get; private set; }

        public IQueryable<Meeting> Apply(IQueryable<Meeting> qry)
        {
            SpecWasApplied = true;

            return qry;
        }
    }
}