using Mmu.CleanDddSimple.Application.Dtos;
using Mmu.CleanDddSimple.Application.Mediation.Models;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;

namespace Mmu.CleanDddSimple.Application.UseCases.CreateMeeting
{
    public class CreateMeetingCommand : ICommand<Either<ServerError, MeetingCreatedResultDto>>
    {
        public CreateMeetingCommand(
            string name,
            string description,
            MeetingTypeDto type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public string Description { get; }
        public string Name { get; }
        public MeetingTypeDto Type { get; }
    }
}