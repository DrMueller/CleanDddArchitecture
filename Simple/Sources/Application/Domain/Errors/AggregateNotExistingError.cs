using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.Domain.Models.Base;

namespace Mmu.CleanDddSimple.Domain.Errors
{
    public class AggregateNotExistingError<TAg> : ServerError
        where TAg : IAggregateRoot
    {
        private readonly long _searchedId;

        public AggregateNotExistingError(long searchedId)
        {
            _searchedId = searchedId;
        }

        public override string ToDescription()
        {
            return $"Aggregate {typeof(TAg).Name} with ID {_searchedId} does not exist.";
        }
    }
}