using System;
using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Dtos;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;
using Mmu.CleanDdd.Shared.Domain.Areas.Specifications;

namespace Mmu.CleanDdd.Individuals.Application.Areas.UseCases.LoadAllIndividuals.Specs
{
    internal class LoadAllIndividualsSpec : ISpecification<Individual, IndividualResultDto>
    {
        public Expression<Func<Individual, IndividualResultDto>> Selector
        {
            get
            {
                return ind => new IndividualResultDto
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    GenderDescription = ind.Gender == Gender.Male ? IndividualResultDto.GenderMale : IndividualResultDto.GenderFemale,
                    LastName = ind.LastName,
                    IndividualId = ind.Id
                };
            }
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.OrderBy(f => f.FirstName);
        }
    }
}