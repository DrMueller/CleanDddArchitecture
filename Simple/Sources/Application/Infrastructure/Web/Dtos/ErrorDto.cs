using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Infrastructure.Web.Dtos
{
    [PublicAPI]
    public class ErrorDto
    {
        public string? Message { get; set; }
    }
}
