using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.Areas.Web.Dtos
{
    [PublicAPI]
    public class AppendAgendaPointRequestDto
    {
        public string PointDescription { get; set; } = null!;
    }
}