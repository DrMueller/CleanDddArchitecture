using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers.Implementation;

namespace Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers
{
    // We really just want the implicit convertion from object --> Either
    // The other way around we would need to know if the either is right or left, which we dont want
    public abstract class Either<TLeft, TRight>
    {
        // ReSharper disable once UnusedMember.Global
        public Either<TLeft, TRight> ToEither(TRight right)
        {
            return new Right<TLeft, TRight>(right);
        }

        // ReSharper disable once UnusedMember.Global
        public Either<TLeft, TRight> ToEither(TLeft left)
        {
            return new Left<TLeft, TRight>(left);
        }

        public static implicit operator Either<TLeft, TRight>(TLeft left)
        {
            return new Left<TLeft, TRight>(left);
        }

        public static implicit operator Either<TLeft, TRight>(TRight right)
        {
            return new Right<TLeft, TRight>(right);
        }
    }
}