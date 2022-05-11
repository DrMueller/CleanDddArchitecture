using JetBrains.Annotations;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Models
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