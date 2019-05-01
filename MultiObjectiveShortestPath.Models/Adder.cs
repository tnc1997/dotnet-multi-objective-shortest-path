using System;

namespace MultiObjectiveShortestPath.Models
{
    public class Adder : IAdder
    {
        public static Adder Default { get; } = new Adder();

        public object Add(object x, object y)
        {
            if (x == null && y == null) throw new ArgumentNullException();

            if (x == null) return y;

            if (y == null) return x;

            if (x is IAddable x1) return x1.AddTo(y);

            if (y is IAddable y1) return y1.AddTo(x);

            if (double.TryParse(x.ToString(), out var x2) && double.TryParse(y.ToString(), out var y2)) return x2 + y2;

            throw new ArgumentException();
        }
    }

    public abstract class Adder<T> : IAdder, IAdder<T>
    {
        public static Adder<T> Default { get; } = CreateAccumulator();

        object IAdder.Add(object x, object y)
        {
            if (x == null && y == null) throw new ArgumentNullException();

            if (x == null) return y;

            if (y == null) return x;

            if (x is T x1 && y is T y1) return Add(x1, y1);

            throw new ArgumentException();
        }

        public abstract T Add(T x, T y);

        private static Adder<T> CreateAccumulator()
        {
            return typeof(IAddable<T>).IsAssignableFrom(typeof(T))
                ? Activator.CreateInstance(typeof(GenericAdder<>).MakeGenericType(typeof(T))) as Adder<T>
                : new ObjectAdder<T>();
        }
    }

    internal class GenericAdder<T> : Adder<T> where T : IAddable<T>
    {
        public override T Add(T x, T y)
        {
            if (x == null && y == null) throw new ArgumentNullException();

            if (x == null) return y;

            if (y == null) return x;

            return x.AddTo(y);
        }
    }

    internal class ObjectAdder<T> : Adder<T>
    {
        public override T Add(T x, T y)
        {
            if (x == null && y == null) throw new ArgumentNullException();

            if (x == null) return y;

            if (y == null) return x;

            return Adder.Default.Add(x, y) is T
                ? (T) Adder.Default.Add(x, y)
                : throw new InvalidCastException();
        }
    }
}