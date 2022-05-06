using JetBrains.Annotations;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Models
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