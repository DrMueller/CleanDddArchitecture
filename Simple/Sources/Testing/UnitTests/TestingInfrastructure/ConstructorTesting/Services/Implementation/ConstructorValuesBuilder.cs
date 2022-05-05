using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Collections;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Servants;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.StringBuilders;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation
{
    internal class ConstructorValuesBuilder<T> : IConstructorValuesBuilder<T>
    {
        private readonly List<ConstructorAssertionSelector<T>> _constructorAssertionSelectors = new();
        private readonly ConstructorInfo _constructorInfo;

        public ConstructorValuesBuilder(ConstructorInfo constructorInfo)
        {
            _constructorInfo = constructorInfo;
        }

        public void Assert()
        {
            var failingAssertions =
                _constructorAssertionSelectors
                    .Select(f => f.Assert())
                    .Where(f => !f.IsSuccess)
                    .ToList();

            if (!failingAssertions.Any())
            {
                return;
            }

            ThrowAssertionFailure(failingAssertions);
        }

        public IConstructorAssertionSelector<T> WithArgumentValues(params object?[] argumentValues)
        {
            var constructorAssertionSelector = new ConstructorAssertionSelector<T>(this, _constructorInfo, argumentValues);
            _constructorAssertionSelectors.Add(constructorAssertionSelector);

            return constructorAssertionSelector;
        }

        private void ThrowAssertionFailure(IEnumerable<AssertionResult> failingAssertions)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Assertion of type '{typeof(T).Name}' failed.");
            sb.AppendLineWithIndentation($"Constructor: {ConstructorInterpreter.GetStringRepresentation(_constructorInfo)}", 2);
            failingAssertions.ForEach(f => sb.AppendLine(f.Message));

            var assertionMessage = sb.ToString();

            while (assertionMessage.EndsWith(Environment.NewLine, StringComparison.OrdinalIgnoreCase))
            {
                assertionMessage = assertionMessage.Substring(0, assertionMessage.Length - Environment.NewLine.Length);
            }

            Xunit.Assert.True(false, assertionMessage);
        }
    }
}