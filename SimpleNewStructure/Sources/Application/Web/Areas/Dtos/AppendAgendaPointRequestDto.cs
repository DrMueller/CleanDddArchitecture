using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Web.Areas.Dtos
{
    [PublicAPI]
    public class AppendAgendaPointRequestDto
    {
        public string PointDescription { get; set; } = null!;
    }
}