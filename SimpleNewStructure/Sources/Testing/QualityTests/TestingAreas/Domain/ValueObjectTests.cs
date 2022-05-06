using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.Domain.Models.Base;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Asserters;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures;
using NetArchTest.Rules;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.Domain
{
    public class ValueObjectTests : QualityTestBase
    {
        private readonly IReadOnlyCollection<Type> _valueObjectTypes;

        public ValueObjectTests(QualityTestFixture fixture)
            : base(fixture)
        {
            _valueObjectTypes = Types.InAssemblies(new List<Assembly> { typeof(Startup).Assembly })
                .That().Inherit(typeof(ValueObject))
                .And().AreNotAbstract()
                .GetTypes()
                .ToList();
        }

        [Fact]
        public void ComparingValueObjects_ValuesNotBeingTheSame_ReturnsFalse()
        {
            // Arrange
            var agendaDesc1 = new AgendaPointDescription("Desc1");
            var agendaDesc2 = new AgendaPointDescription("Desc2");

            // Act
            var areEqual = agendaDesc1 == agendaDesc2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void ComparingValuesObjects_ValuesBeingTheSame_ReturnsTrue()
        {
            // Arrange
            var agendaDesc1 = new AgendaPointDescription("Desc1");
            var agendaDesc2 = new AgendaPointDescription("Desc1");

            // Act
            var areEqual = agendaDesc1 == agendaDesc2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void ValueObjects_AreImmutable()
        {
            TypeImmutableAsserter.AssertTypesAreImmutable(_valueObjectTypes);
        }
    }
}