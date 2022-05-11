using System;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.Repositories
{
    public interface IAggregateSpecification<TAg>
        where TAg : IAggregateRoot
    {
        public Expression<Func<TAg, bool>> Filter { get; }
    }
}