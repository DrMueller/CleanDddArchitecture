using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Specs;
using Mmu.CleanDdd.Shared.Domain.Services.Querying;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Interactors.Implementation
{
    public class LoadAllIndividualsInteractor : ILoadAllIndividualsInteractor
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsInteractor(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualResultDto>> ExecuteAsync()
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}