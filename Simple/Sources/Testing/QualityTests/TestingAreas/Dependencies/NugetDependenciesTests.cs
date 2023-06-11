using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.SolutionMetadata.Services;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.Dependencies
{
    public class NugetDependenciesTests
    {
        [Fact]
        public void NugetDependencies_AreUnique()
        {
            // Arrange
            var vsSolution = VsSolutionFactory.Create();
            
            // Act
            var actualDuplicates = vsSolution.CalculateDuplicatedNugets();

            // Assert
            actualDuplicates.Should().BeEmpty();
        }
    }
}
