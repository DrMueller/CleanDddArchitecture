using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;

namespace Mmu.CleanDdd.Individuals.Application.Areas.CreateIndividual
{
    public class CreateIndividualCommand : ICommand<CreateIndividualResultDto>
    {
        public CreateIndividualCommand(CreateIndividualRequestDto requestDto)
        {
            Guard.ObjectNotNull(() => requestDto);

            RequestDto = requestDto;
        }

        public CreateIndividualRequestDto RequestDto { get; }
    }
}