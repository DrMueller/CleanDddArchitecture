using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Domain.Models
{
    [PublicAPI]
    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Business terms")]
    public enum MeetingType
    {
        Short,
        Long
    }
}