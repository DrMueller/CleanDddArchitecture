using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Mmu.CleanDddSimple.Areas.Application.UseCases.LoadAgendaOverview;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Areas.Application.UseCases.LoadAgendaOverview
{
    public class AgendaOverviewSpecUnitTests
    {
        private readonly AgendaOverviewSpec _sut;

        public AgendaOverviewSpecUnitTests()
        {
            _sut = new AgendaOverviewSpec();
        }

        [Fact]
        public void Applying_TakesMaximumAmountOfEntries()
        {
            // Arrange
            var agendas = Enumerable
                .Range(0, 15)
                .Select(_ => new Agenda())
                .AsQueryable();

            // Act
            var actualAgendas = _sut.Apply(agendas);

            // Assert
            actualAgendas.Count().Should().Be(AgendaOverviewSpec.MaxEntries);
        }

        [Fact]
        public void Selecting_SelectsDto()
        {
            // Arrange
            var agenda = new Agenda();

            var points = new List<string>
            {
                "Tra1",
                "Tra2"
            };

            foreach (var p in points)
            {
                agenda.AddAgendaPoint(p);
            }

            // Act
            var actualOverviewDto = _sut.Selector.Compile()(agenda);

            // Assert
            actualOverviewDto.AgendaPoints.Should().BeEquivalentTo(points);
        }
    }
}