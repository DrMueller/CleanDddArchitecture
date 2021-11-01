using System;

namespace Mmu.CleanDdd.Shared.Domain.Areas.Models
{
    public interface IHasCreatedDate
    {
        DateTime CreatedDate { get; set; }
    }
}