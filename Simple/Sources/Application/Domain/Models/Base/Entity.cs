using System;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Domain.Models.Base.Technical;

namespace Mmu.CleanDddSimple.Domain.Models.Base
{
    [PublicAPI]
    public abstract class Entity : IHasTimeStamps
    {
        public DateTime CreatedDate { get; private set; }

        public long Id { get; }

        public DateTime UpdatedDate { get; private set; }
        DateTime IHasTimeStamps.CreatedDate
        {
#pragma warning disable CA1033 // Interface methods should be callable by child types
            set => CreatedDate = value;
#pragma warning restore CA1033 // Interface methods should be callable by child types
        }

        DateTime IHasTimeStamps.UpdatedDate
        {
#pragma warning disable CA1033 // Interface methods should be callable by child types
            set => UpdatedDate = value;
#pragma warning restore CA1033 // Interface methods should be callable by child types
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity compareTo)
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id.ToString()).GetHashCode(StringComparison.InvariantCulture);
        }

        public static bool operator ==(Entity? a, Entity? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}