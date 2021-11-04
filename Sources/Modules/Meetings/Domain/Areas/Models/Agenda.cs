using System.Collections.Generic;
using System.Linq;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class Agenda : Entity
    {
        public long MeetingId { get; set; }

        private readonly IList<AgendaPoint> _points;
        public Agenda()
        {
            _points = new List<AgendaPoint>();
        }

        public IReadOnlyCollection<AgendaPoint> Points => _points.ToList();

        public void AddAgendaPoint(string descriptionText)
        {
            var agendaPoint = new AgendaPoint(_points.Count + 1);
            agendaPoint.AddDescription(descriptionText);
            _points.Add(agendaPoint);
        }
    }
}