using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Application.Dtos
{
    [PublicAPI]
    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Business terms")]
    public enum MeetingTypeDto
    {
        Short,
        Long
    }
}