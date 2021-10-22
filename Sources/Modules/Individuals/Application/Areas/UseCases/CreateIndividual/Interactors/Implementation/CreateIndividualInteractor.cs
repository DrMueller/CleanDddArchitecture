using System;
using System.Threading.Tasks;
using Mmu.CleanDdd.CrossCutting.Areas.Logging.Services;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Dtos;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.Shared.Domain.Services.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.CreateIndividual.Interactors.Implementation
{
    public class CreateIndividualInteractor : ICreateIndividualInteractor
    {
        private readonly ILoggingService _loggingService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateIndividualInteractor(
            ILoggingService loggingService,
            IUnitOfWorkFactory uowFactory)
        {
            _loggingService = loggingService;
            _uowFactory = uowFactory;
        }

        public async Task<CreateIndividualResultDto> ExecuteAsync(CreateIndividualRequestDto dto)
        {
            _loggingService.LogInformation("Creating new Individual..");

            var individual = new Individual
            {
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName + " " + Guid.NewGuid(),
                Gender = dto.Gender,
                LastName = dto.LastName + " " + Guid.NewGuid()
            };

            using (var uow = _uowFactory.Create())
            {
                var individualRepo = uow.GetRepository<IIndividualRepository>();
                await individualRepo.UpsertAsync(individual);
                await uow.SaveAsync();
            }

            _loggingService.LogInformation("Individual created");

            return new CreateIndividualResultDto
            {
                IndividualId = individual.Id
            };
        }
    }
}