using System.Linq;
using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Specs;
using Mmu.CleanDdd.Shared.Domain.Services.Querying;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Interactors.Implementation
{
    public class LoadFirstIndividualWithRolesInteractor : ILoadFirstIndividualWithRolesInteractor
    {
        private readonly IQueryService _queryService;

        public LoadFirstIndividualWithRolesInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IndividualWithRolesDto> ExecuteAsync()
        {
            var individuals = await _queryService.QueryAsync(new LoadIndividualsWithRolesSpec());
            var dto = individuals.Select(
                ind => new IndividualWithRolesDto
                {
                    AmountOfRoles = ind.Roles.Count,
                    IndividualId = ind.Id
                }).First();

            return dto;
        }
    }
}