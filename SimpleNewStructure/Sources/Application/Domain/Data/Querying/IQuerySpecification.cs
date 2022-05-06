using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Data.Querying
{
    public interface IQuerySpecification<T, TResult> : IQuerySpecification<T>
        where T : Entity
    {
        Expression<Func<T, TResult>> Selector { get; }
    }

    public interface IQuerySpecification<T>
        where T : Entity
    {
        IQueryable<T> Apply(IQueryable<T> qry);
    }
}