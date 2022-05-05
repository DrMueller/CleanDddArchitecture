using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.AppendAgendaPoint
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