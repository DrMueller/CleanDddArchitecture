namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Models
{
    public class AssertionResult
    {
        private AssertionResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string Message { get; }

        public static AssertionResult CreateFail(string message)
        {
            return new AssertionResult(false, message);
        }

        public static AssertionResult CreateSuccess()
        {
            return new AssertionResult(true, string.Empty);
        }
    }
}