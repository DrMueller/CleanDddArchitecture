using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UpdateIndividual
{
    public class UpdateIndividualCommandHandler : IRequestHandler<UpdateIndividualCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public UpdateIndividualCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<Unit> Handle(UpdateIndividualCommand request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();
            var indRepo = uow.GetRepository<IIndividualRepository>();

            var ind = await indRepo.LoadAsync(request.Dto.IndividualId);
            ind.FirstName = request.Dto.NewFirstName;

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}