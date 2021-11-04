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

        public Meeting(string name, string description, MeetingType meetingType)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => description);

            Name = name;
            Description = description;
            MeetingType = meetingType;
        }

        public Agenda Agenda { get; private set; }
        public string Description { get; }
        public MeetingType MeetingType { get;}

        public string Name { get; }

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