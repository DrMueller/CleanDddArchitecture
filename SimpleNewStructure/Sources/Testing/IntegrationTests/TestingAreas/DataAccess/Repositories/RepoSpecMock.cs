using System;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Models;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.Repositories
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