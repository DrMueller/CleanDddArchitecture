using Mmu.CleanDdd.Shared.Domain.Areas.Models;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Organisation : AggregateRoot
    {
        public string Name { get; }
    }
}