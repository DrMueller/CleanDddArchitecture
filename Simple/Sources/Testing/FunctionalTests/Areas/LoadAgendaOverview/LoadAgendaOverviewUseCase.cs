using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace Mmu.CleanDddSimple.FunctionalTests.Areas.LoadAgendaOverview
{
    [FeatureDescription(
        @"In order to use meetings
as a user
I want to create a meetings")]
    public partial class LoadAgendaOverviewUseCase
    {
        [Scenario]
        public async Task Load_Agenda_Overview()
        {
            await Runner.RunScenarioAsync(
                Given_meetings_with_agenda_points_exist,
                When_the_overview_is_loaded,
                Then_the_agenda_overview_is_loaded);
        }
    }
}