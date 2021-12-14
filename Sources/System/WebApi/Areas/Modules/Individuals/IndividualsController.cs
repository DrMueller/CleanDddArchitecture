using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDdd.Individuals.Application.Areas.CreateIndividual;
using Mmu.CleanDdd.Individuals.Application.Areas.DeleteIndividual;
using Mmu.CleanDdd.Individuals.Application.Areas.LoadAllIndividuals;
using Mmu.CleanDdd.Individuals.Application.Areas.UpdateIndividual;
using Mmu.CleanDdd.SharedKernel.Application.Areas.Mediation.Services;

namespace Mmu.CleanDdd.WebApi.Areas.Modules.Individuals
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IMediationService _mediator;

        public IndividualsController(
            IMediationService mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await _mediator.SendAsync(new CreateIndividualCommand(dto));

            return Ok(result);
        }

        [HttpDelete("{individualId:long}")]
        public async Task<IActionResult> DeleteIndividualAsync([FromRoute] long individualId)
        {
            await _mediator.SendAsync(new DeleteIndividualCommand(individualId));

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualResultDto>>> LoadAllAsync()
        {
            var allIndividuals = await _mediator.SendAsync(new LoadAllIndividualsQuery());

            return Ok(allIndividuals);
        }

        [HttpPut("{individualId:long}")]
        public async Task<IActionResult> UpdateIndividualAsync([FromRoute] long individualId, [FromBody] IndividualToUpdateDto dto)
        {
            await _mediator.SendAsync(new UpdateIndividualCommand(dto));

            return Ok();
        }
    }
}