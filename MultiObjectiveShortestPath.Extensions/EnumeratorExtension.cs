using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Extensions
{
    public static class EnumeratorExtension
    {
        public static IEnumerable<TSource> ToEnumerable<TSource>(this IEnumerator<TSource> enumerator)
        {
            while (enumerator.MoveNext()) yield return enumerator.Current;
        }
    }
}