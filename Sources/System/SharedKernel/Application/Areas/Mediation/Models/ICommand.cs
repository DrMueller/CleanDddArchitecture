using MediatR;

namespace Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Models
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }

    public interface ICommand : IRequest
    {
    }
}