using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmu.CleanDdd.CrossCutting.Areas.LanguageExtensions.Collections
{
    public static class EnumerableExtensions
    {
        public static async Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> selector)
        {
            foreach (var entry in source)
            {
                await selector(entry);
            }
        }
    }
}