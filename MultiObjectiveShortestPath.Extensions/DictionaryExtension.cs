using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Extensions
{
    public static class DictionaryExtension
    {
        public static double Average<TKey>(this IDictionary<TKey, double> dictionary)
        {
            return dictionary.Average(pair => pair.Value);
        }

        public static IDictionary<TKey, double> Averages<TKey>(this IEnumerable<IDictionary<TKey, double>> dictionaries)
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.Merge().Averages();
        }

        public static IDictionary<TKey, double> Averages<TKey>(this IDictionary<TKey, IEnumerable<double>> dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(Enumerable.Average);
        }

        public static TValue Max<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            where TValue : IComparable<TValue>
        {
            return dictionary.Max(pair => pair.Value);
        }

        public static IDictionary<TKey, TValue> Maxima<TKey, TValue>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries
        ) where TValue : IComparable<TValue>
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.Merge().Maxima();
        }

        public static IDictionary<TKey, TValue> Maxima<TKey, TValue>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary
        ) where TValue : IComparable<TValue>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(Enumerable.Max);
        }

        public static IDictionary<TKey, TResult> Maxima<TKey, TValue, TResult>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary,
            Func<TValue, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(values => values.Max(selector));
        }

        public static IDictionary<TKey, TValue> MaximaBy<TKey, TValue, TResult>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary,
            Func<TValue, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return dictionary.Select(pair => pair.Value.MaxBy(selector));
        }

        public static IDictionary<TKey, IEnumerable<TValue>> Merge<TKey, TValue>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.Merge((key, values) => values);
        }

        public static IDictionary<TKey, TResult> Merge<TKey, TValue, TResult>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries,
            Func<TKey, IEnumerable<TValue>, TResult> selector
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return dictionaries
                .SelectMany(values => values)
                .GroupBy(pair => pair.Key)
                .ToDictionary(
                    pairs => pairs.Key,
                    pairs => selector(pairs.Key, pairs.Select(pair => pair.Value))
                );
        }

        public static TValue Min<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary
        ) where TValue : IComparable<TValue>
        {
            return dictionary.Min(pair => pair.Value);
        }

        public static IDictionary<TKey, TValue> Minima<TKey, TValue>(
            this IEnumerable<IDictionary<TKey, TValue>> dictionaries
        ) where TValue : IComparable<TValue>
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.Merge().Minima();
        }

        public static IDictionary<TKey, TValue> Minima<TKey, TValue>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary
        ) where TValue : IComparable<TValue>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(Enumerable.Min);
        }

        public static IDictionary<TKey, TResult> Minima<TKey, TValue, TResult>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary,
            Func<TValue, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(values => values.Min(selector));
        }

        public static IDictionary<TKey, TValue> MinimaBy<TKey, TValue, TResult>(
            this IDictionary<TKey, IEnumerable<TValue>> dictionary,
            Func<TValue, TResult> selector
        ) where TResult : IComparable<TResult>
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return dictionary.Select(pair => pair.Value.MinBy(selector));
        }

        public static IDictionary<TKey, double> Normalize<TKey>(
            this IDictionary<TKey, double> dictionary
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            var min = dictionary.Min();
            var max = dictionary.Max();

            return dictionary.Select(pair => (pair.Value - min) / (max - min));
        }

        public static IEnumerable<IDictionary<TKey, double>> Normalize<TKey>(
            this IEnumerable<IDictionary<TKey, double>> dictionaries
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            var list = dictionaries.ToList();

            var minima = list.Minima();
            var maxima = list.Maxima();

            return list.Select(dictionary => dictionary.Normalize(minima, maxima));
        }

        public static IDictionary<TKey, double> Normalize<TKey>(
            this IDictionary<TKey, double> dictionary,
            IDictionary<TKey, double> minima,
            IDictionary<TKey, double> maxima
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (minima == null) throw new ArgumentNullException(nameof(minima));
            if (maxima == null) throw new ArgumentNullException(nameof(maxima));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");
            if (minima.Count == 0) throw new InvalidOperationException("This dictionary is empty.");
            if (maxima.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            if (!dictionary.Keys.OrderBy(key => key).SequenceEqual(minima.Keys.OrderBy(key => key)))
                throw new ArgumentException();
            if (!dictionary.Keys.OrderBy(key => key).SequenceEqual(maxima.Keys.OrderBy(key => key)))
                throw new ArgumentException();

            return dictionary.Select(pair => (pair.Value - minima[pair.Key]) / (maxima[pair.Key] - minima[pair.Key]));
        }

        public static IDictionary<TKey, TResult> Select<TKey, TValue, TResult>(
            this IDictionary<TKey, TValue> dictionary,
            Func<TValue, TResult> selector
        )
        {
            return dictionary.ToDictionary(
                pair => pair.Key,
                pair => selector(pair.Value)
            );
        }

        public static IDictionary<TKey, TResult> Select<TKey, TValue, TResult>(
            this IDictionary<TKey, TValue> dictionary,
            Func<KeyValuePair<TKey, TValue>, TResult> selector
        )
        {
            return dictionary.ToDictionary(
                pair => pair.Key,
                selector
            );
        }

        public static IDictionary<TKey, double> Standardize<TKey>(
            this IDictionary<TKey, double> dictionary
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            var average = dictionary.Average();
            var standardDeviation = dictionary.StandardDeviation();

            return dictionary.Select(pair => (pair.Value - average) / standardDeviation);
        }

        public static IEnumerable<IDictionary<TKey, double>> Standardize<TKey>(
            this IEnumerable<IDictionary<TKey, double>> dictionaries
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            var list = dictionaries.ToList();

            var averages = list.Averages();
            var standardDeviations = list.StandardDeviations();

            return list.Select(dictionary => dictionary.Standardize(averages, standardDeviations));
        }

        public static IDictionary<TKey, double> Standardize<TKey>(
            this IDictionary<TKey, double> dictionary,
            IDictionary<TKey, double> averages,
            IDictionary<TKey, double> standardDeviations
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (averages == null) throw new ArgumentNullException(nameof(averages));
            if (standardDeviations == null) throw new ArgumentNullException(nameof(standardDeviations));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");
            if (averages.Count == 0) throw new InvalidOperationException("This dictionary is empty.");
            if (standardDeviations.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            if (!dictionary.Keys.OrderBy(key => key).SequenceEqual(averages.Keys.OrderBy(key => key)))
                throw new ArgumentException();
            if (!dictionary.Keys.OrderBy(key => key).SequenceEqual(standardDeviations.Keys.OrderBy(key => key)))
                throw new ArgumentException();

            return dictionary.Select(pair => (pair.Value - averages[pair.Key]) / standardDeviations[pair.Key]);
        }

        public static double StandardDeviation<TKey>(this IDictionary<TKey, double> dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.StandardDeviation(pair => pair.Value);
        }

        public static IDictionary<TKey, double> StandardDeviations<TKey>(
            this IEnumerable<IDictionary<TKey, double>> dictionaries
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.Merge().StandardDeviations();
        }

        public static IDictionary<TKey, double> StandardDeviations<TKey>(
            this IDictionary<TKey, IEnumerable<double>> dictionary
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Select(pair => pair.Value.StandardDeviation());
        }

        public static IDictionary<TNewKey, IDictionary<TOldKey, TValue>> Transpose<TOldKey, TNewKey, TValue>(
            this IDictionary<TOldKey, IDictionary<TNewKey, TValue>> dictionary
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.Transpose(values => values);
        }

        public static IDictionary<TNewKey, TResult> Transpose<TOldKey, TNewKey, TValue, TResult>(
            this IDictionary<TOldKey, IDictionary<TNewKey, TValue>> dictionary,
            Func<IDictionary<TOldKey, TValue>, TResult> selector
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return dictionary
                .SelectMany(
                    pair => pair.Value,
                    (pair, value) => new
                    {
                        OldKey = pair.Key,
                        NewKey = value.Key,
                        value.Value
                    }
                ).GroupBy(
                    arg => arg.NewKey,
                    (key, enumerable) => new
                    {
                        Key = key,
                        Value = enumerable.ToDictionary(
                            arg => arg.OldKey,
                            arg => arg.Value
                        )
                    }
                ).ToDictionary(
                    arg => arg.Key,
                    arg => selector(arg.Value)
                );
        }

        public static IDictionary<TKey, double> Weight<TKey>(
            this IDictionary<TKey, double> dictionary,
            double weight
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            return dictionary.Select(pair => pair.Value * weight);
        }

        public static IEnumerable<IDictionary<TKey, double>> Weight<TKey>(
            this IEnumerable<IDictionary<TKey, double>> dictionaries,
            IDictionary<TKey, double> weights
        )
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));
            if (weights == null) throw new ArgumentNullException(nameof(weights));

            return dictionaries.Select(dictionary => dictionary.Weight(weights));
        }

        public static IDictionary<TKey, double> Weight<TKey>(
            this IDictionary<TKey, double> dictionary,
            IDictionary<TKey, double> weights
        )
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (weights == null) throw new ArgumentNullException(nameof(weights));

            if (dictionary.Count == 0) throw new InvalidOperationException("This dictionary is empty.");
            if (weights.Count == 0) throw new InvalidOperationException("This dictionary is empty.");

            if (!dictionary.Keys.OrderBy(key => key).SequenceEqual(weights.Keys.OrderBy(key => key)))
                throw new ArgumentException();

            return dictionary.Select(pair => pair.Value * weights[pair.Key]);
        }
    }
}