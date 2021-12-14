using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Querying;

namespace Mmu.CleanDdd.Individuals.Application.Areas.LoadAllIndividuals
{
    public class LoadAllIndividualsQueryHandler : IRequestHandler<LoadAllIndividualsQuery, IReadOnlyCollection<IndividualResultDto>>
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsQueryHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualResultDto>> Handle(LoadAllIndividualsQuery request, CancellationToken cancellationToken)
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}