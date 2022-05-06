using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation.PropertyAsserters
{
    public interface IPropertyValueAsserter<in TP>
    {
        AssertionResult Assert(TP actualPropertyValue);
    }
}