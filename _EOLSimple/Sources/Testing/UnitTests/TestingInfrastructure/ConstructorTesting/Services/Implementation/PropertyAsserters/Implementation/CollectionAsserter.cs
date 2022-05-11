using System.Collections.Generic;
using System.Linq;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation.PropertyAsserters.Servants;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Servants;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation.PropertyAsserters.Implementation
{
    internal class CollectionAsserter<TP> : IPropertyValueAsserter<TP>
    {
        private readonly IEnumerable<object>? _expectedValues;

        public CollectionAsserter(TP expectedValues)
        {
            _expectedValues = expectedValues as IEnumerable<object>;
        }

        public AssertionResult Assert(TP? actualPropertyValue)
        {
            var notEqualMessage = FailingMessageFactory.CreateNotEqualMessage(_expectedValues, actualPropertyValue);

            var actualIsNull = actualPropertyValue == null;
            var expectedIsNull = _expectedValues == null;

            // Both Null = fine
            if (actualIsNull && expectedIsNull)
            {
                return AssertionResult.CreateSuccess();
            }

            // One Null = Not fine
            if (!actualIsNull ^ !expectedIsNull)
            {
                return AssertionResult.CreateFail(notEqualMessage);
            }

            // Compare enumerables
            if (actualPropertyValue is not IEnumerable<object> actualCollection)
            {
                var notEnumerableMessage = $"Actual '{ObjectInterpreter.GetStringRepresentation(actualPropertyValue)}' is not an IEnumerable.";

                return AssertionResult.CreateFail(notEnumerableMessage);
            }

            if (HasSameElementsAs(actualCollection, _expectedValues))
            {
                return AssertionResult.CreateSuccess();
            }

            return AssertionResult.CreateFail(notEqualMessage);
        }

        private static bool HasSameElementsAs<T>(
            IEnumerable<T>? first,
            IEnumerable<T>? second) where T : notnull
        {
            if (first == null || second == null)
            {
                return false;
            }

            var firstMap = first.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var secondMap = second.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            return
                firstMap.Keys.All(x => secondMap.ContainsKey(x) && firstMap[x] == secondMap[x]) &&
                secondMap.Keys.All(x => firstMap.ContainsKey(x) && secondMap[x] == firstMap[x]);
        }
    }
}