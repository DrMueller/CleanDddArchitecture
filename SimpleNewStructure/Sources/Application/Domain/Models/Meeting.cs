using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.Errors.Implementation;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Invariance;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Models
{
    [PublicAPI]
    public class Meeting : AggregateRoot, IMeeting
    {
        private readonly List<Participant> _participants;

        public Meeting(
            string name, string description, MeetingType meetingType)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => description);

            Name = name;
            Description = description;
            MeetingType = meetingType;
            _participants = new List<Participant>();
            Agenda = new Agenda();
        }

        public Agenda Agenda { get; private set; }
        public string Description { get; }
        public MeetingType MeetingType { get; }
        public string Name { get; }
        public IReadOnlyCollection<Participant> Participants => _participants;

        public Either<ServerError, Participant> AddParticipant(string name)
        {
            if (_participants.Any(f => f.Name == name))
            {
                return new GenericError($"Participant with name {name} is already added.");
            }

            var participant = new Participant(name);
            _participants.Add(participant);

            return participant;
        }
    }
}