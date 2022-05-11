using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    [PublicAPI]
    public interface IConstructorAssertionSelector<T>
    {
        IConstructorValuesBuilder<T> Fails();

        IConstructorPropertyMapper<T> Maps();

        IConstructorValuesBuilder<T> Succeeds();
    }
}