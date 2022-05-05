using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Invariance;

namespace Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors.Implementation
{
    public class GenericError : ServerError
    {
        public GenericError(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);

            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public override string ToDescription()
        {
            return ErrorMessage;
        }
    }
}