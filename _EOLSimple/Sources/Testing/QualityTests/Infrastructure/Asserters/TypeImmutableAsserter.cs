using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.Asserters
{
    internal static class TypeImmutableAsserter
    {
        internal static void AssertTypesAreImmutable(IEnumerable<Type> types)
        {
            var failingTypes = types.Where(
                f =>
                    f.GetFields().Any(x => !x.IsInitOnly)
                    || f.GetProperties().Any(x => x.CanWrite));

            failingTypes.Should().BeEmpty();
        }
    }
}