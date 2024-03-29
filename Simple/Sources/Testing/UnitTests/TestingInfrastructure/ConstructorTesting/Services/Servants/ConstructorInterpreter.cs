﻿using System.Linq;
using System.Reflection;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Servants
{
    internal static class ConstructorInterpreter
    {
        internal static string GetStringRepresentation(ConstructorInfo ctorInfo)
        {
            var parameterNames = ctorInfo.GetParameters().Select(f => f.Name);
            var result = string.Join(", ", parameterNames);

            return result;
        }
    }
}