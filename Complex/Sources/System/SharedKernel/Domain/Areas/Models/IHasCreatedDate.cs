using System;

namespace Mmu.CleanDdd.SharedKernel.Domain.Areas.Models
{
    public interface IHasCreatedDate
    {
        DateTime CreatedDate { get; set; }
    }
}