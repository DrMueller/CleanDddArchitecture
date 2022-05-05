using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanDdd.QualityTests.Infrastructure.Asserters;
using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;
using NetArchTest.Rules;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Areas.Layers.Domain
{
    public class ValueObjectTests : AssemblyTestBase
    {
        private readonly IReadOnlyCollection<Type> _valueObjectTypes;

        public ValueObjectTests(AssemblyTestFixture fixture) : base(fixture)
        {
            _valueObjectTypes = Types.InAssemblies(Fixture.Assemblies)
                .That().Inherit(typeof(ValueObject<>))
                .And().AreNotAbstract()
                .GetTypes()
                .ToList();
        }

        [Fact]
        public void ValueObjects_AreImmutable()
        {
            TypeImmutableAsserter.AssertTypesAreImmutable(_valueObjectTypes);
        }
    }
}
