namespace Mmu.CleanDdd.Meetings.Application.Areas.UseCases.Meetings.CreateMeeting.Dtos
{
    public class CreateMeetingRequestDto
    {
        public string Description { get; set; }

        public MeetingTypeDto MeetingType { get; set; }
        public string Name { get; set; }
    }
}