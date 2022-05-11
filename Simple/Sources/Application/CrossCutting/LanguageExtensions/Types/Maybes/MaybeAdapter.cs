using System;
using System.Threading.Tasks;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;

namespace Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes
{
    public static class MaybeAdapter
    {
        public static Maybe<TNew> Map<T, TNew>(this Maybe<T> maybe, Func<T, TNew> map)
        {
            if (maybe is None<T>)
            {
                return None.Value;
            }

            var someValue = (Some<T>)maybe;

            return map(someValue);
        }

        public static T Reduce<T>(
            this Maybe<T> maybe,
            Func<T> whenNone)
        {
            if (maybe is None<T>)
            {
                return whenNone();
            }

            return (Some<T>)maybe;
        }

        public static async Task<T> ReduceAsync<T>(
            this Maybe<T> maybe,
            Func<Task<T>> whenNone)
        {
            if (maybe is None<T>)
            {
                return await whenNone();
            }

            return (Some<T>)maybe;
        }

        public static T ReduceThrow<T>(this Maybe<T> maybe)
        {
            if (maybe is None<T>)
            {
                throw new ArgumentException("Maybe is none");
            }

            return (Some<T>)maybe;
        }

        public static Either<TNone, T> ToEither<TNone, T>(this Maybe<T> maybe, Func<TNone> whenNone)
        {
            if (maybe is None<T>)
            {
                return whenNone();
            }

            return maybe.ReduceThrow();
        }
    }
}