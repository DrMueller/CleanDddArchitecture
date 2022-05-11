using Mmu.CleanDddSimple.Areas.Application.Dtos;
using Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;

namespace Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting
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