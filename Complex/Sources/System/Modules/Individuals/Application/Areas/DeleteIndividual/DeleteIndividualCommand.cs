using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models;

namespace Mmu.CleanDdd.Individuals.Application.Areas.DeleteIndividual
{
    public class DeleteIndividualCommand : ICommand
    {
        public DeleteIndividualCommand(long individualId)
        {
            Guard.ValueNotDefault(() => individualId);

            IndividualId = individualId;
        }

        public long IndividualId { get; }
    }
}