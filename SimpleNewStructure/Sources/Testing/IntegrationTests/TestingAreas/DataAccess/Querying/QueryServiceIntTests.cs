using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.Domain.Data.Querying;
using Mmu.CleanDddSimple.IntegrationTests.TestingInfrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.Querying
{
    public class QueryServiceIntTests : IntegrationTestBase
    {
        private readonly IQueryService _sut;

        public QueryServiceIntTests(IntegrationTestFixture fixture) : base(fixture)
        {
            _sut = fixture.ServiceProvider.GetRequiredService<IQueryService>();
        }

        [Fact]
        public async Task QueryingContentProjection_AppliesSpecification()
        {
            // Arrange
            var spec = new ProjectionSpecMock();

            // Act
            await _sut.QueryAsync(spec);

            // Assert
            spec.SpecWasApplied.Should().BeTrue();
            spec.SelectorWasApplied.Should().BeTrue();
        }

        [Fact]
        public async Task QueryingEntities_AppliesSpecification()
        {
            // Arrange
            var spec = new EntitySpecMock();

            // Act
            await _sut.QueryAsync(spec);

            // Assert
            spec.SpecWasApplied.Should().BeTrue();
        }
    }
}