using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    public static class ConstructorTestBuilderFactory
    {
        public static IConstructorSelector<T> Constructing<T>()
        {
            return new ConstructorSelector<T>();
        }
    }
}