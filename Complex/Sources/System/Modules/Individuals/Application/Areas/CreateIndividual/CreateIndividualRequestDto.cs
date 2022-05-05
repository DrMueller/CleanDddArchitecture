using System;
using Mmu.CleanDdd.Individuals.Domain.Areas.Models;

namespace Mmu.CleanDdd.Individuals.Application.Areas.CreateIndividual
{
    public class CreateIndividualRequestDto
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
    }
}