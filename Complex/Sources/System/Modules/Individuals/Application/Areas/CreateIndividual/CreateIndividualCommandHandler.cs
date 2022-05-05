using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.CleanDdd.CrossCutting.Areas.Logging.Services;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Individuals.Domain.Areas.Repositories;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.UnitOfWorks;

namespace Mmu.CleanDdd.Individuals.Application.Areas.CreateIndividual
{
    public class CreateIndividualCommandHandler : IRequestHandler<CreateIndividualCommand, CreateIndividualResultDto>
    {
        private readonly ILoggingService _loggingService;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateIndividualCommandHandler(
            ILoggingService loggingService,
            IUnitOfWorkFactory uowFactory)
        {
            _loggingService = loggingService;
            _uowFactory = uowFactory;
        }

        public async Task<CreateIndividualResultDto> Handle(CreateIndividualCommand request, CancellationToken cancellationToken)
        {
            _loggingService.LogInformation("Creating new Individual..");

            var individual = new Individual
            {
                BirthDate = request.RequestDto.BirthDate,
                FirstName = request.RequestDto.FirstName + " " + Guid.NewGuid(),
                Gender = request.RequestDto.Gender,
                LastName = request.RequestDto.LastName + " " + Guid.NewGuid()
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