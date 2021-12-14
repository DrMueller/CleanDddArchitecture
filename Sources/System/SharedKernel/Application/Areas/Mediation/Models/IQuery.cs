using MediatR;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}