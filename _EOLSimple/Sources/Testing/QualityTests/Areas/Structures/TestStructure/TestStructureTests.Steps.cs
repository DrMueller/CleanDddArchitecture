using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.Areas.Structures.TestStructure
{
    public partial class TestStructureTests
    {
        private static readonly Assembly _applicationAssembly = typeof(Program).Assembly;

        private static void AssertTestStructure(
            string testSuffix,
            Assembly testAssembly)
        {
            // Arrange
            var testTypes = testAssembly.GetTypes()
                .Where(f => f.Name.EndsWith(testSuffix, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var implementationTypes = _applicationAssembly.GetTypes().ToList();
            var errorMessages = new List<string>();

            // Act & Assert
            foreach (var testClass in testTypes)
            {
                var implementationClassName = CreateImplementationClassFullName(testClass, testSuffix, true);
                var logicTypes = implementationTypes.Where(f => f.FullName == implementationClassName).ToList();

                if (!logicTypes.Any())
                {
                    implementationClassName = CreateImplementationClassFullName(testClass, testSuffix, false);
                    logicTypes = implementationTypes.Where(f => f.FullName == implementationClassName).ToList();
                }

                if (!logicTypes.Any())
                {
                    errorMessages.Add($"Searched, but did not find implementation type {implementationClassName}.");
                }

                if (logicTypes.Count > 1)
                {
                    errorMessages.Add($"Found multiple implementation types {implementationClassName} .");
                }
            }

            if (!errorMessages.Any())
            {
                return;
            }

            var sb = new StringBuilder();

            foreach (var errMessage in errorMessages)
            {
                sb.AppendLine(errMessage);
            }

            Assert.True(false, sb.ToString());
        }

        private static string CreateImplementationClassFullName(Type testClass, string testSuffix, bool appendImplementation)
        {
            // The logic follows the convention of having test-assembly like Mmu.CleanDddSimple.DatabaseTests and a top-level ordenr "TestingAreas
            var logicTypeName = testClass.Name.Replace(testSuffix, string.Empty, StringComparison.OrdinalIgnoreCase);
            var namespaceParts = testClass.Namespace!.Split('.').ToList();

            var testingAreasPartIndex = namespaceParts.IndexOf("TestingAreas");
            var testAssemblyPart = namespaceParts.ElementAt(testingAreasPartIndex - 1);
            var pathToReplace = $".{testAssemblyPart}.TestingAreas";

            var logicTypeNamespacePart = testClass.Namespace!.Replace(pathToReplace, string.Empty, StringComparison.Ordinal);

            if (appendImplementation)
            {
                logicTypeNamespacePart += ".Implementation";
            }

            var logicTypeFullName = $"{logicTypeNamespacePart}.{logicTypeName}";

            return logicTypeFullName;
        }
    }
}