using System;
using Mmu.CleanDdd.Shared.Domain.Areas.Models;

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