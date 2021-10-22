using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Specs;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.DomainServices.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Interactors.Implementation
{
    public class AppendRoleInteractor : IAppendRoleInteractor
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public AppendRoleInteractor(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task ExecuteAsync(long individualId, AppendRoleRequestDto dto)
        {
            using var uow = _uowFactory.Create();

            var indRepo = uow.GetRepository<IIndividualRepository>();
            var spec = new LoadIndividualWithRolesSpec(individualId);
            var individual = await indRepo.LoadAsync(spec);

            individual.Roles.Add(
                new Role
                {
                    Description = dto.RoleDescription,
                    Organisation = new Organisation
                    {
                        Name = dto.OrganisationName
                    }
                });

            await uow.SaveAsync();
        }
    }
}