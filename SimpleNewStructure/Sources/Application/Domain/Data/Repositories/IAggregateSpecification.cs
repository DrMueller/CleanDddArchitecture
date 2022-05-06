using System;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Data.Repositories
{
    public interface IAggregateSpecification<TAg>
        where TAg : IAggregateRoot
    {
        public Expression<Func<TAg, bool>> Filter { get; }
    }
}