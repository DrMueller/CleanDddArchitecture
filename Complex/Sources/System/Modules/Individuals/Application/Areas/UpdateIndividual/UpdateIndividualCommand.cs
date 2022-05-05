using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UpdateIndividual
{
    public class UpdateIndividualCommand : ICommand
    {
        public UpdateIndividualCommand(IndividualToUpdateDto dto)
        {
            Guard.ObjectNotNull(() => dto);

            Dto = dto;
        }

        public IndividualToUpdateDto Dto { get; }
    }
}