using System;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services
{
    [PublicAPI]
    public interface IConstructorSelector<T>
    {
        IConstructorValuesBuilder<T> UsingConstructorWithParameters(params Type[] argTypes);

        IConstructorValuesBuilder<T> UsingDefaultConstructor();
    }
}