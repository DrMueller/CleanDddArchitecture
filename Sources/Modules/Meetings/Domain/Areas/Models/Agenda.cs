using System.Collections.Generic;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    public class Agenda : Entity
    {
        private long _meetingId;

        private readonly List<AgendaPoint> _points;

        public Agenda()
        {
            _points = new List<AgendaPoint>();
        }

        public IReadOnlyCollection<AgendaPoint> Points => _points;

        public void AddAgendaPoint(string descriptionText)
        {
            _points.Add(
                new AgendaPoint
                {
                    Description = new AgendaPointDescription
                    {
                        Text = descriptionText
                    }
                });
        }
    }
}