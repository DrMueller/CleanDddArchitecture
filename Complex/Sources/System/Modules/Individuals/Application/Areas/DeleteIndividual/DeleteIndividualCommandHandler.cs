using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.DeleteIndividual
{
    public class DeleteIndividualCommandHandler : IRequestHandler<DeleteIndividualCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public DeleteIndividualCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Unit> Handle(DeleteIndividualCommand request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetRepository<IIndividualRepository>();
            await indRepo.DeleteAsync(request.IndividualId);

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}