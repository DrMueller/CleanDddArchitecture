using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.AppendAgendaPoint
{
    public class AppendAgendaPointCommand : ICommand
    {
        public AppendAgendaPointCommand(
            long meetingId,
            string agendaPointDescription)
        {
            MeetingId = meetingId;
            AgendaPointDescription = agendaPointDescription;
        }

        public string AgendaPointDescription { get; }
        public long MeetingId { get; }
    }
}