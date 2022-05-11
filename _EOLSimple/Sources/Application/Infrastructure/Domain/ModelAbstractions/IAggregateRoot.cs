using System.Diagnostics.CodeAnalysis;

namespace Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface")]
    public interface IAggregateRoot
    {
    }
}