using Mmu.CleanDddSimple.Application.Areas.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Fixtures;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingAreas.Application.Areas.UseCases.CreateMeeting
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