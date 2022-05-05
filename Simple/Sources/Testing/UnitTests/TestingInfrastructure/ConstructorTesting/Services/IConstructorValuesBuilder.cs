namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    public interface IConstructorValuesBuilder<T>
    {
        void Assert();

        IConstructorAssertionSelector<T> WithArgumentValues(params object?[] argumentValues);
    }
}