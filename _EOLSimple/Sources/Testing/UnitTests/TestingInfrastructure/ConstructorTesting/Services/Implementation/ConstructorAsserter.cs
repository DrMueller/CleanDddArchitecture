using System.Reflection;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Servants;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation
{
    internal class ConstructorAsserter<T> : IAssertable
    {
        private readonly object?[] _argumentValues;
        private readonly bool _constructingShouldFail;
        private readonly ConstructorInfo _constructorInfo;

        public ConstructorAsserter(
            ConstructorInfo constructorInfo,
            bool constructingShouldFail,
            params object?[] argumentValues)
        {
            _constructorInfo = constructorInfo;
            _argumentValues = argumentValues;
            _constructingShouldFail = constructingShouldFail;
        }

        public AssertionResult Assert()
        {
            var canCreateobject = ObjectFactory.TryCreatingObject(out T _, _constructorInfo, _argumentValues);

            switch (canCreateobject)
            {
                case true when _constructingShouldFail:
                {
                    var shouldFailMessage = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_argumentValues)}' should fail.";

                    return AssertionResult.CreateFail(shouldFailMessage);
                }

                case false when !_constructingShouldFail:
                {
                    var shouldNotFailMessage = $"    Arguments '{ObjectInterpreter.GetStringRepresentation(_argumentValues)}' should not fail.";

                    return AssertionResult.CreateFail(shouldNotFailMessage);
                }

                default:
                    return AssertionResult.CreateSuccess();
            }
        }
    }
}