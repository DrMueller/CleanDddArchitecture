using System.Collections.Generic;
using JetBrains.Annotations;
using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.Meetings.Domain.Areas.DomainEvents;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Meetings.Domain.Areas.Models
{
    [PublicAPI]
    public class Meeting : AggregateRoot
    {
        private List<Participant> _participants;

        public Meeting(string name, string description, MeetingType type)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => description);

            _name = name;
            _description = description;
            _meetingType = type;
        }

        public Meeting()
        {
        }

        public Agenda Agenda { get; private set; }
        public string Description => _description;
        public MeetingType MeetingType => _meetingType;
        public string Name => _name;
        private string _description;

        private string _name;
        private MeetingType _meetingType;

        public IReadOnlyCollection<Participant> Participants => _participants;

        public void AddParticipant(string name)
        {
            _participants ??= new List<Participant>();
            _participants.Add(new Participant(name));

            AddDomainEvent(new ParticipantAddedDomainEvent(name));
        }

        public void CreateAgenda()
        {
            Agenda = new Agenda();
        }
    }
}