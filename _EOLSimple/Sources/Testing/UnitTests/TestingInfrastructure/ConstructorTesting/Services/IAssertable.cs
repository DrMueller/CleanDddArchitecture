using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    internal interface IAssertable
    {
        AssertionResult Assert();
    }
}