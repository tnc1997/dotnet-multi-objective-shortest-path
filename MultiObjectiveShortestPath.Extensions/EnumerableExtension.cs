using System;
using System.Collections.Generic;
using System.Linq;
using MultiObjectiveShortestPath.Models;

namespace MultiObjectiveShortestPath.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var results = new HashSet<TResult>();

            foreach (var source in enumerable)
                if (results.Add(selector(source)))
                    yield return source;
        }

        public static TSource MaxBy<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.MaxBy(selector, Comparer<TResult>.Default);
        }

        public static TSource MaxBy<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector,
            IComparer<TResult> comparer
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            TSource Func(TSource max, TSource value)
            {
                return comparer.Compare(selector(value), selector(max)) > 0
                    ? value
                    : max;
            }

            return enumerable.Aggregate(Func);
        }

        public static TSource MinBy<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.MinBy(selector, Comparer<TResult>.Default);
        }

        public static TSource MinBy<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector,
            IComparer<TResult> comparer
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            TSource Func(TSource min, TSource value)
            {
                return comparer.Compare(selector(value), selector(min)) < 0
                    ? value
                    : min;
            }

            return enumerable.Aggregate(Func);
        }

        public static IEnumerable<double> Normalize(this IEnumerable<double> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var list = enumerable.ToList();

            if (list.Count == 0) throw new InvalidOperationException("This enumerable is empty.");

            var min = list.Min();
            var max = list.Max();

            return list.Select(value => (value - min) / (max - min));
        }

        public static IEnumerable<double> Normalize<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, double> selector
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.Select(selector).Normalize();
        }

        public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> enumerable, int count)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            
            using (var enumerator = enumerable.GetEnumerator())
            {
                var hasRemainingItems = true;

                var cache = new Queue<TSource>(count + 1);

                while (hasRemainingItems)
                {
                    hasRemainingItems = enumerator.MoveNext();

                    if (!hasRemainingItems) continue;

                    cache.Enqueue(enumerator.Current);

                    if (cache.Count > count) yield return cache.Dequeue();
                }
            }
        }

        public static IEnumerable<double> Standardize(this IEnumerable<double> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var list = enumerable.ToList();

            if (list.Count == 0) throw new InvalidOperationException("This enumerable is empty.");

            var average = list.Average();
            var standardDeviation = list.StandardDeviation();

            return list.Select(value => (value - average) / standardDeviation);
        }

        public static IEnumerable<double> Standardize<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, double> selector
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.Select(selector).Standardize();
        }

        public static double StandardDeviation(this IEnumerable<double> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var variance = enumerable.Variance();

            return Math.Sqrt(variance);
        }

        public static double StandardDeviation<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, double> selector
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.Select(selector).StandardDeviation();
        }

        public static Queue<TSource> ToQueue<TSource>(this IEnumerable<TSource> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var queue = new Queue<TSource>();

            foreach (var source in enumerable) queue.Enqueue(source);

            return queue;
        }

        public static Stack<TSource> ToStack<TSource>(this IEnumerable<TSource> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var queue = new Stack<TSource>();

            foreach (var source in enumerable) queue.Push(source);

            return queue;
        }

        public static double Variance(this IEnumerable<double> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            var list = enumerable.ToList();

            if (list.Count == 0) throw new InvalidOperationException("This enumerable is empty.");

            var average = list.Average();

            return list.Aggregate((aggregate, value) =>
            {
                var difference = value - average;

                return aggregate + difference * difference;
            }) / list.Count;
        }

        public static double Variance<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, double> selector
        )
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return enumerable.Select(selector).Variance();
        }

        public static TPath WeightedSumShortestPath<TPath, TObjectiveKey>(
            this IEnumerable<TPath> paths,
            IDictionary<TObjectiveKey, double> weights,
            Func<TPath, IDictionary<TObjectiveKey, double>> selector
        )
        {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            if (weights == null) throw new ArgumentNullException(nameof(weights));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return paths.ToDictionary(path => path, selector).WeightedSumShortestPath(weights);
        }

        public static TPath WeightedSumShortestPath<TPath, TObjectiveKey>(
            this IDictionary<TPath, IDictionary<TObjectiveKey, double>> objectives,
            IDictionary<TObjectiveKey, double> weights
        )
        {
            if (objectives == null) throw new ArgumentNullException(nameof(objectives));
            if (weights == null) throw new ArgumentNullException(nameof(weights));

            return objectives.Transpose().WeightedSumShortestPath(weights);
        }

        public static TPath WeightedSumShortestPath<TPath, TObjectiveKey>(
            this IDictionary<TObjectiveKey, IDictionary<TPath, double>> paths,
            IDictionary<TObjectiveKey, double> weights
        )
        {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            if (weights == null) throw new ArgumentNullException(nameof(weights));

            var weightedPaths = paths
                .Select(pair => pair.Value.Normalize())
                .Select(pair => pair.Value.Weight(weights[pair.Key]))
                .Transpose()
                .Select(pair => pair.Value.Values.Aggregate((sum, value) => sum + value));

            return weightedPaths.MaxBy(pair => pair.Value).Key;
        }

        public static IDictionary<TObjectiveKey, TPath> WeightedSumShortestPaths<TPath, TObjectiveKey>(
            this IEnumerable<TPath> paths,
            IDictionary<TObjectiveKey, ExtremizeType> extremizeTypes,
            Func<TPath, IDictionary<TObjectiveKey, double>> selector
        )
        {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            if (extremizeTypes == null) throw new ArgumentNullException(nameof(extremizeTypes));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return paths.ToDictionary(path => path, selector).WeightedSumShortestPaths(extremizeTypes);
        }

        public static IDictionary<TObjectiveKey, TPath> WeightedSumShortestPaths<TPath, TObjectiveKey>(
            this IDictionary<TPath, IDictionary<TObjectiveKey, double>> objectives,
            IDictionary<TObjectiveKey, ExtremizeType> extremizeTypes
        )
        {
            if (objectives == null) throw new ArgumentNullException(nameof(objectives));
            if (extremizeTypes == null) throw new ArgumentNullException(nameof(extremizeTypes));

            return objectives.Transpose().WeightedSumShortestPaths(extremizeTypes);
        }

        public static IDictionary<TObjectiveKey, TPath> WeightedSumShortestPaths<TPath, TObjectiveKey>(
            this IDictionary<TObjectiveKey, IDictionary<TPath, double>> paths,
            IDictionary<TObjectiveKey, ExtremizeType> extremizeTypes
        )
        {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            if (extremizeTypes == null) throw new ArgumentNullException(nameof(extremizeTypes));

            TPath ElementSelector(KeyValuePair<TObjectiveKey, IDictionary<TPath, double>> pair)
            {
                KeyValuePair<TPath, double> extremum;

                double Selector(KeyValuePair<TPath, double> keyValuePair)
                {
                    return keyValuePair.Value;
                }

                switch (extremizeTypes[pair.Key])
                {
                    case ExtremizeType.Minimize:
                        extremum = pair.Value.MinBy(Selector);
                        break;
                    case ExtremizeType.Maximize:
                        extremum = pair.Value.MaxBy(Selector);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return extremum.Key;
            }

            return paths.ToDictionary(pair => pair.Key, ElementSelector);
        }
    }
}