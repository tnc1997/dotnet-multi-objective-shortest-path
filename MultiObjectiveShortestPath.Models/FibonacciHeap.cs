using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class FibonacciHeap<TKey, TValue> : IMinHeap<TKey, TValue>
    {
        public FibonacciHeap() : this(Comparer<TKey>.Default)
        {
        }

        public FibonacciHeap(IComparer<TKey> comparer)
        {
            Comparer = comparer;
        }

        internal IComparer<TKey> Comparer { get; }

        internal FibonacciHeapVertex<TKey, TValue> Min { get; set; }

        public int Count { get; private set; }

        public bool IsEmpty => Min == null;

        public void Clear()
        {
            Count = 0;
            Min = null;
        }

        public IMinHeapVertex<TKey, TValue> ExtractMin()
        {
            if (IsEmpty) return FindMin();

            var min = Min;

            var child = min.Child;

            // While the min vertex has children, then remove them and insert them into the root list.
            while (min.Degree > 0)
            {
                var temp = child.Right;

                // Removes the child vertex from the child list.
                child.Left.Right = child.Right;
                child.Right.Left = child.Left;

                // Inserts the child vertex into the root list.
                Insert(child);

                // Removes the child vertex from its parent.
                child.Parent = null;

                child = temp;

                min.Degree--;
            }

            // Removes the min vertex from the root list.
            min.Left.Right = min.Right;
            min.Right.Left = min.Left;

            // If the min vertex points to itself, then set the min to null; otherwise, update the min vertex.
            if (min == min.Right)
            {
                Min = null;
            }
            else
            {
                Min = min.Right;

                Consolidate();
            }

            Count--;

            return min;
        }

        public IMinHeapVertex<TKey, TValue> FindMin()
        {
            return Min;
        }

        public IMinHeapVertex<TKey, TValue> Insert(TKey key, TValue value)
        {
            var vertex = new FibonacciHeapVertex<TKey, TValue>(this, key, value);

            if (IsEmpty)
            {
                vertex.Left = vertex;
                vertex.Right = vertex;

                Min = vertex;
            }
            else
            {
                Insert(vertex);

                if (Comparer.Compare(vertex.Key, Min.Key) < 0) Min = vertex;
            }

            Count++;

            return vertex;
        }

        private void Consolidate()
        {
            var oneOverLogPhi = 1.0 / Math.Log((1.0 + Math.Sqrt(5.0)) / 2.0);
            var length = Math.Floor(Math.Log(Count) * oneOverLogPhi) + 1;
            var list = new List<FibonacciHeapVertex<TKey, TValue>>(Convert.ToInt32(length));

            for (var i = 0; i < length; i++) list.Add(null);

            var noOfRoots = 0;
            var x = Min;

            if (!IsEmpty)
            {
                noOfRoots++;
                x = x.Right;

                while (x != Min)
                {
                    noOfRoots++;
                    x = x.Right;
                }
            }

            while (noOfRoots > 0)
            {
                var degree = x.Degree;
                var next = x.Right;

                while (true)
                {
                    var y = list[degree];

                    if (y == null) break;

                    if (Comparer.Compare(x.Key, y.Key) > 0)
                    {
                        var temp = y;
                        y = x;
                        x = temp;
                    }

                    Link(y, x);

                    list[degree] = null;

                    degree++;
                }

                list[degree] = x;

                x = next;

                noOfRoots--;
            }

            Min = null;

            for (var i = 0; i < length; i++)
            {
                var y = list[i];

                if (y == null) continue;

                if (Min == null) Min = y;

                y.Left.Right = y.Right;
                y.Right.Left = y.Left;

                Insert(y);

                if (Comparer.Compare(y.Key, Min.Key) < 0) Min = y;
            }
        }

        /// <summary>
        ///     Inserts a vertex into the root list.
        /// </summary>
        /// <param name="vertex">The vertex that will be inserted into the root list.</param>
        internal void Insert(FibonacciHeapVertex<TKey, TValue> vertex)
        {
            vertex.Left = Min;
            vertex.Right = Min.Right;
            Min.Right = vertex;
            vertex.Right.Left = vertex;
        }

        private void Link(FibonacciHeapVertex<TKey, TValue> child, FibonacciHeapVertex<TKey, TValue> parent)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            if (parent == null) throw new ArgumentNullException(nameof(parent));

            child.Left.Right = child.Right;
            child.Right.Left = child.Left;

            child.Parent = parent;

            if (parent.Child == null)
            {
                child.Left = child;
                child.Right = child;

                parent.Child = child;
            }
            else
            {
                child.Left = parent.Child;
                child.Right = parent.Child.Right;
                parent.Child.Right = child;
                child.Right.Left = child;
            }

            parent.Degree++;

            child.IsMarked = false;
        }

        private void Meld(FibonacciHeap<TKey, TValue> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            if (other.Comparer != Comparer)
                throw new ArgumentException("Cannot meld heaps using different comparators.", nameof(other));

            if (IsEmpty && other.IsEmpty) return;

            if (IsEmpty)
            {
                Min = other.Min;
            }
            else if (!other.IsEmpty)
            {
                Min.Right.Left = other.Min.Left;
                other.Min.Left.Right = Min.Right;
                Min.Right = other.Min;
                other.Min.Left = Min;

                if (Comparer.Compare(other.Min.Key, Min.Key) < 0) Min = other.Min;
            }

            Count += other.Count;

            other.Clear();
        }
    }
}