using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.CleanDdd.QualityTests.Infrastructure.Asserters;
using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.DomainEvents;
using NetArchTest.Rules;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Areas.Layers.Domain
{
    public class DomainEventTests : AssemblyTestBase
    {
        [Fact]
        public void DomainEvents_EndWithDomainEvent()
        {
            var typeNames = _domainEventTypes.Select(f => f.Name);

            foreach (var tn in typeNames)
            {
                tn.Should().EndWith("DomainEvent");
            }
        }

        [Fact]
        public void DomainEvents_AreImmutable()
        {
            TypeImmutableAsserter.AssertTypesAreImmutable(_domainEventTypes);
        }

        private readonly IReadOnlyCollection<Type> _domainEventTypes;


        public DomainEventTests(AssemblyTestFixture fixture) : base(fixture)
        {
            _domainEventTypes = Types.InAssemblies(Fixture.Assemblies)
                .That().Inherit(typeof(DomainEventBase))
                .Or().ImplementInterface(typeof(IDomainEvent))
                .And().AreNotAbstract()
                .GetTypes()
                .ToList();
        }
    }
}
