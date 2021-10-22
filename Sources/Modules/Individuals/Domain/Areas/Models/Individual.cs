using System;
using System.Collections.Generic;
using Mmu.CleanDdd.Shared.Domain.DomainModels;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Individual : AggregateRoot
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}