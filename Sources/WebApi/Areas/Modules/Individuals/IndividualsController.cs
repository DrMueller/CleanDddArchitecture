﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDdd.Individuals.Application.Areas.Module;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.AppendRole.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.DeleteIndividual.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadFirstIndividualWithRoles.Interactors;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.UpdateIndividual.Interactors;

namespace Mmu.CleanDdd.WebApi.Areas.Modules.Individuals
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualsModule individualsModule;

        public IndividualsController(
            IIndividualsModule individualsModule)
        {
            this.individualsModule = individualsModule;
        }

        [HttpPost("{individualId:long}/roles")]
        public async Task<IActionResult> AppendRoleAsync([FromRoute] long individualId, [FromBody] AppendRoleRequestDto dto)
        {
            await
                this.individualsModule
                    .GetInteractor<IAppendRoleInteractor>()
                    .ExecuteAsync(individualId, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CreateIndividualResultDto>> CreateIndividualAsync(CreateIndividualRequestDto dto)
        {
            var result = await this.individualsModule
                .GetInteractor<ICreateIndividualInteractor>()
                .ExecuteAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<IndividualResultDto>>> LoadAllAsync()
        {
            var allIndividuals = await this.individualsModule
                    .GetInteractor<ILoadAllIndividualsInteractor>()
                    .ExecuteAsync();

            return Ok(allIndividuals);
        }

        [HttpPut("{individualId:long}")]
        public async Task<IActionResult> UpdateIndividualAsync([FromRoute] long individualId, [FromBody] IndividualToUpdateDto dto)
        { 
            await this.individualsModule
                .GetInteractor<IUpdateIndividualInteractor>()
                .ExecuteAsync(individualId, dto);

            return Ok();
        }

        [HttpDelete("{individualId:long}")]
        public async Task<IActionResult> DeleteIndividualAsync([FromRoute] long individualId)
        {
            await this.individualsModule
                .GetInteractor<IDeleteIndividualInteractor>()
                .ExecuteAsync(individualId);

            return Ok();
        }


        [HttpGet("first")]
        public async Task<ActionResult<IndividualWithRolesDto>> LoadFirstIndividualWithRolesASync()
        {
            var individualWithRoles = await this.individualsModule
                    .GetInteractor<ILoadFirstIndividualWithRolesInteractor>()
                    .ExecuteAsync();

            return Ok(individualWithRoles);
        }
    }
}
