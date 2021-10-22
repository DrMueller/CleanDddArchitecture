using Mmu.CleanDdd.Shared.Domain.Models;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Role : Entity
    {
        public string Description { get; set; }

        public Individual Individual { get; set; }

        public Organisation Organisation { get; set; }
    }
}