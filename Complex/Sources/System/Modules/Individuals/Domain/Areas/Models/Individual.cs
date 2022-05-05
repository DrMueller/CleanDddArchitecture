using System;
using Mmu.CleanDdd.SharedKernel.Domain.Areas.Models;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Individual : AggregateRoot
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
    }
}