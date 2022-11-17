using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Invariance;

namespace Mmu.CleanDddSimple.CrossCutting.Errors
{
    public class GenericServerError : ServerError
    {
        public GenericServerError(string errorMessage)
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