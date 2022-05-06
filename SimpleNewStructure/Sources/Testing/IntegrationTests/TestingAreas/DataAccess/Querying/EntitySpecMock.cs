using System.Linq;
using Mmu.CleanDddSimple.Domain.Data.Querying;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.Querying
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