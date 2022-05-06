using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers.Implementation;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers
{
    // Taken from https://app.pluralsight.com/course-player?clipId=99342073-37aa-4438-b61d-cf582553798b
    [PublicAPI]
    public static class EitherAdapters
    {
        public static Either<TLeft, TNewRight> MapEitherRight<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either, Func<TRight, Either<TLeft, TNewRight>> map)
        {
            return either is Right<TLeft, TRight> right
                ? map(right)
                : (TLeft)(Left<TLeft, TRight>)either;
        }

        public static Either<TLeft, TNewRight> MapRight<TLeft, TRight, TNewRight>(
            this Either<TLeft, TRight> either, Func<TRight, TNewRight> map)
        {
            return either is Right<TLeft, TRight> right
                ? map(right)
                : (TLeft)(Left<TLeft, TRight>)either;
        }

        public static TRight ReduceRight<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TLeft, TRight> map)
        {
            return either is Left<TLeft, TRight> left
                ? map(left)
                : (Right<TLeft, TRight>)either;
        }

        public static TRight ReduceRightThrow<TLeft, TRight>(
            this Either<TLeft, TRight> either)
        {
            if (either is Left<TLeft, TRight>)
            {
                throw new ArgumentException("Either is left");
            }

            return (Right<TLeft, TRight>)either;
        }

        public static Either<TLeft, TRight> ReduceRightWhen<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TLeft, TRight> map, Func<TLeft, bool> when)
        {
            return either is Left<TLeft, TRight> bound && when(bound)
                ? map(bound)
                : either;
        }

        public static Maybe<TLeft> ToLeftMaybe<TLeft, TRight>(
            this Either<TLeft, TRight> either)
        {
            return either is Left<TLeft, TRight> left
                ? left.ToTLeft()
                : Maybe.CreateNone<TLeft>();
        }

        public static async Task<Either<TLeft, TRight>> WhenRightAsync<TLeft, TRight>(
            this Either<TLeft, TRight> either, Func<TRight, Task> action)
        {
            if (either is Right<TLeft, TRight> right)
            {
                await action(right);
            }

            return either;
        }
    }
}