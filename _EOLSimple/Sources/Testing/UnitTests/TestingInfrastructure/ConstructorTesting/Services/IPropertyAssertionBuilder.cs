using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    [PublicAPI]
    public interface IPropertyAssertionBuilder<T, in TP> : IAssertableProperty<T>
    {
        IConstructorPropertyMapper<T> WithValue(TP expectedValue);

        IConstructorPropertyMapper<T> WithValues(TP values);
    }
}