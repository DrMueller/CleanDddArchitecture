using System.Collections.Generic;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Collections;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Builders.Base;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.AggregateBuilders.Builders
{
    public class MeetingBuilder : AggregateBuilderbase<IMeeting>
    {
        private readonly IList<string> _agendaPointDescriptions;
        private Maybe<string> _description;

        public MeetingBuilder()
        {
            _agendaPointDescriptions = new List<string>();
            _description = None.Value;
        }

        public override IMeeting Build()
        {
            var meeting = new Meeting(
                "Test Name",
                _description.Reduce(() => "Test Description"),
                MeetingType.Long);

            _agendaPointDescriptions.ForEach(f => meeting.Agenda.AddAgendaPoint(f));

            return meeting;
        }

        public MeetingBuilder WithAgendaPoint(string description)
        {
            _agendaPointDescriptions.Add(description);

            return this;
        }

        public MeetingBuilder WithDescription(string description)
        {
            _description = description;

            return this;
        }
    }
}