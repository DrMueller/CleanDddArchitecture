using JetBrains.Annotations;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Builders.Base
{
    [PublicAPI]
    public abstract class AggregateBuilderbase<T> : IAggregateBuilder
        where T : IAggregateRoot
    {
        public abstract T Build();
    }
}