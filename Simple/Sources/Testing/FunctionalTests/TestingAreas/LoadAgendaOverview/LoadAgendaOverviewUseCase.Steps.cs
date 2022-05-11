using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.CleanDddSimple.Application.UseCases.LoadAgendaOverview;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.FunctionalTests.TestingInfrastructure.Fixtures;
using Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Builders;
using Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Factories;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingAreas.LoadAgendaOverview
{
    public partial class LoadAgendaOverviewUseCase : WebApiTestBase
    {
        private List<IMeeting>? _meetings;
        private List<AgendaOverviewResultDto>? _resultDtos;

        public LoadAgendaOverviewUseCase(WebApiTestFixture fixture)
            : base(fixture)
        {
        }

        private async Task Given_meetings_with_agenda_points_exist()
        {
            _meetings = Enumerable.Range(1, 10).Select(
                i => AggregateBuilderFactory
                    .Create<MeetingBuilder>()
                    .WithDescription($"Description {i}")
                    .WithAgendaPoint("Tra1")
                    .WithAgendaPoint("Tra2")
                    .WithAgendaPoint("Tra3")
                    .Build()).ToList();

            await AggregatePersister.PersistAsync(_meetings.ToArray());
        }

        private Task Then_the_agenda_overview_is_loaded()
        {
            _resultDtos.Should().NotBeNull();
            _resultDtos!.Count.Should().Be(AgendaOverviewSpec.MaxEntries);

            foreach (var dto in _resultDtos)
            {
                var agenda = _meetings!.Single(f => f.Agenda.Id == dto.AgendaId);
                var expectedPoints = agenda.Agenda
                    .Points.Select(f => f.Description.Text)
                    .OrderBy(f => f)
                    .ToList();

                dto.AgendaPoints.Should().BeEquivalentTo(expectedPoints);
            }

            return Task.CompletedTask;
        }

        private async Task When_the_overview_is_loaded()
        {
            var apiResult = await SendAsync(HttpMethod.Get, "api/meetings/agendaoverview");
            apiResult.Response.EnsureSuccessStatusCode();
            _resultDtos = await apiResult.ReadContentAsync<List<AgendaOverviewResultDto>>();
        }
    }
}