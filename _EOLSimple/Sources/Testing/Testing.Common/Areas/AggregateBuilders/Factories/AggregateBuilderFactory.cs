using Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Builders.Base;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Factories
{
    public static class AggregateBuilderFactory
    {
        public static T Create<T>()
            where T : IAggregateBuilder, new()
        {
            var builder = new T();

            return builder;
        }
    }
}