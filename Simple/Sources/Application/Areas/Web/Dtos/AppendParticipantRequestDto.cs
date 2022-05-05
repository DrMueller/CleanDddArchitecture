using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Areas.Web.Dtos
{
    [PublicAPI]
    public class AppendParticipantRequestDto
    {
        [Required]
        public string ParticipantName { get; set; } = null!;
    }
}