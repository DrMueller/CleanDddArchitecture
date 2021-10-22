using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDdd.Shared.Domain.Models;

namespace Mmu.CleanDdd.Shared.Domain.Specifications
{
    public interface ISpecification<TAg, TResult> : ISpecification<TAg>
        where TAg : AggregateRoot
    {
        Expression<Func<TAg, TResult>> Selector { get; }
    }

    public interface ISpecification<TAg>
        where TAg : AggregateRoot
    {
        IQueryable<TAg> Apply(IQueryable<TAg> qry);
    }
}