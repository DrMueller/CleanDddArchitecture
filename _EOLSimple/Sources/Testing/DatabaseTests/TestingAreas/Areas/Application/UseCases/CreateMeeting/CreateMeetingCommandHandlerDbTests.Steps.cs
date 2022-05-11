using Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Fixtures;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingAreas.Areas.Application.UseCases.CreateMeeting
{
    public partial class CreateMeetingCommandHandlerDbTests : DatabaseTestBase
    {
        private readonly CreateMeetingCommandHandler _sut;

        public CreateMeetingCommandHandlerDbTests(DatabaseTestFixture fixture)
            : base(fixture)
        {
            _sut = fixture.LamarContainer.GetInstance<CreateMeetingCommandHandler>();
        }
    }
}