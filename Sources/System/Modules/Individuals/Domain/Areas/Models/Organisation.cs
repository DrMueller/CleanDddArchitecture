using Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Invariance;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Organisation : AggregateRoot
    {
        public Organisation(string name)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Name = name;
        }

        public string Name { get; }
    }
}