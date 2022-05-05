using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.Domain.ModelAbstractions;

namespace Mmu.CleanDddSimple.Areas.Domain.Models
{
    [PublicAPI]
    public record AgendaPointDescription : ValueObject
    {
        // ReSharper disable once ConvertToPrimaryConstructor
        public AgendaPointDescription(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}