using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    public interface IAssertableProperty<in T>
    {
        AssertionResult Assert(T objectToCheck);
    }
}