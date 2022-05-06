using Mmu.CleanDddSimple.Application.Areas.Dtos;
using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;

namespace Mmu.CleanDddSimple.Application.Areas.UseCases.CreateMeeting
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