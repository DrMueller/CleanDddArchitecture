using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Infrastructure.DataAccess.Querying
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