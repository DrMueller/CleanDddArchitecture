using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.Infrastructure.DataAccess.Querying
{
    public class ProjectionSpecMock : IQuerySpecification<Meeting, string>
    {
        public Expression<Func<Meeting, string>> Selector
        {
            get
            {
                SelectorWasApplied = true;

                return f => f.Description;
            }
        }
        public bool SelectorWasApplied { get; private set; }
        public bool SpecWasApplied { get; private set; }

        public IQueryable<Meeting> Apply(IQueryable<Meeting> qry)
        {
            SpecWasApplied = true;

            return qry;
        }
    }
}