using JetBrains.Annotations;

namespace Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.FunctionResults
{
    public class FunctionResult<T> : FunctionResult
    {
        public FunctionResult(bool isSuccess, T value)
            : base(isSuccess)
        {
            Value = value;
        }

        public T Value { get; }
    }

    [PublicAPI]
    public class FunctionResult
    {
        public FunctionResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public static FunctionResult<T> CreateFailure<T>()
        {
            return new FunctionResult<T>(false, default);
        }

        public static FunctionResult<T> CreateFromDefault<T>(T value)
        {
            return Equals(value, default) ? CreateFailure<T>() : CreateSuccess(value);
        }

        public static FunctionResult<T> CreateSuccess<T>(T value)
        {
            return new FunctionResult<T>(true, value);
        }
    }
}