using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace Mmu.CleanDddSimple.FunctionalTests.TestingAreas.CreateMeeting
{
    [FeatureDescription(
        @"In order to use meetings
as a user
I want to create a meetings")]
    public partial class CreateMeetingUseCase
    {
        [Scenario]
        public async Task Create_Meeting()
        {
            await Runner.RunScenarioAsync(
                When_a_meeting_is_created,
                Then_the_creation_succeeded,
                Then_the_response_contains_the_meeting_id,
                Then_the_meeting_is_created);
        }
    }
}