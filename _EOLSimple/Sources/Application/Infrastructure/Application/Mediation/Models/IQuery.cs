using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace Mmu.CleanDddSimple.Infrastructure.Application.Mediation.Models
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker Interface")]
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}