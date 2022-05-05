using System;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.Infrastructure.DataAccess.Repositories
{
    public class RepoSpecMock : IAggregateSpecification<IMeeting>
    {
        public Expression<Func<IMeeting, bool>> Filter
        {
            get
            {
                FilterWasApplied = true;

                return m => true;
            }
        }
        public bool FilterWasApplied { get; private set; }
    }
}