﻿using System.Collections.Generic;
using Mmu.CleanDdd.Shared.Domain.DomainModels;

namespace Mmu.CleanDdd.Individuals.Domain.Areas.Models
{
    public class Organisation : AggregateRoot
    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}