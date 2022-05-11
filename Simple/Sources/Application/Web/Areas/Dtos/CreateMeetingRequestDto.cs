using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Application.Dtos;

namespace Mmu.CleanDddSimple.Web.Areas.Dtos
{
    [PublicAPI]
    public class CreateMeetingRequestDto
    {
        [Required]
        public string Description { get; set; } = null!;
        public MeetingTypeDto MeetingType { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}