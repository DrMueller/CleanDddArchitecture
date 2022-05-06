using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Web.Areas.Dtos
{
    [PublicAPI]
    public class AppendParticipantRequestDto
    {
        [Required]
        public string ParticipantName { get; set; } = null!;
    }
}