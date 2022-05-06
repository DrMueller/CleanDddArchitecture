using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Web.Areas.Dtos.Base
{
    [PublicAPI]
    public class ErrorDto
    {
        public string? Message { get; set; }
    }
}
