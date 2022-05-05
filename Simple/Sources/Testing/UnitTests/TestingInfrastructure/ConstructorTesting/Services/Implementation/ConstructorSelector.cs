using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Invariance;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Implementation
{
    internal class ConstructorSelector<T> : IConstructorSelector<T>
    {
        public IConstructorValuesBuilder<T> UsingConstructorWithParameters(params Type[] argTypes)
        {
            var ctorInfo = GetConstructors().FirstOrDefault(f => CheckIfMatchesArgumentTypes(f, argTypes));

            if (ctorInfo == null)
            {
                throw new Exception("Could not find constructor");
            }

            return CreateConstructorValuesBuilder(ctorInfo);
        }

        public IConstructorValuesBuilder<T> UsingDefaultConstructor()
        {
            var ctorInfo = GetConstructors()
                .OrderBy(f => f.GetParameters().Length)
                .FirstOrDefault();

            if (ctorInfo == null)
            {
                throw new Exception("Could not find constructor");
            }

            return CreateConstructorValuesBuilder(ctorInfo);
        }

        private static bool CheckIfMatchesArgumentTypes(MethodBase constructorInfo, params Type[] argTypes)
        {
            var constructorParamterTypes = constructorInfo.GetParameters().Select(f => f.ParameterType).ToList();

            return constructorParamterTypes.SequenceEqual(argTypes);
        }

        private static IConstructorValuesBuilder<T> CreateConstructorValuesBuilder(ConstructorInfo constructorInfo)
        {
            Guard.ObjectNotNull(() => constructorInfo);
            var constructorValuesBuilder = new ConstructorValuesBuilder<T>(constructorInfo);

            return constructorValuesBuilder;
        }

        private static IEnumerable<ConstructorInfo> GetConstructors()
        {
            return typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}