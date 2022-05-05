using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Areas.Domain.Models
{
    [PublicAPI]
    public class Participant : Entity
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}