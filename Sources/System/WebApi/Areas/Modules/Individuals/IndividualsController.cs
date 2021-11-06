using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDdd.Individuals.Application.Areas.Module;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.DeleteIndividual.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Interactors;

namespace Mmu.CleanDdd.WebApi.Areas.Modules.Individuals
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualsModule _individualsModule;

        public IndividualsController(
            IIndividualsModule individualsModule)
        {
            _individualsModule = individualsModule;
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await _individualsModule
                .GetInteractor<ICreateIndividualInteractor>()
                .ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{individualId:long}")]
        public async Task<IActionResult> DeleteIndividualAsync([FromRoute] long individualId)
        {
            await _individualsModule
                .GetInteractor<IDeleteIndividualInteractor>()
                .ExecuteAsync(individualId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualResultDto>>> LoadAllAsync()
        {
            var allIndividuals = await _individualsModule
                .GetInteractor<ILoadAllIndividualsInteractor>()
                .ExecuteAsync();

            return Ok(allIndividuals);
        }

        [HttpPut("{individualId:long}")]
        public async Task<IActionResult> UpdateIndividualAsync([FromRoute] long individualId, [FromBody] IndividualToUpdateDto dto)
        {
            await _individualsModule
                .GetInteractor<IUpdateIndividualInteractor>()
                .ExecuteAsync(individualId, dto);

            return Ok();
        }
    }
}