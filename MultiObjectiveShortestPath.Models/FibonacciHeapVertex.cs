using System;

namespace MultiObjectiveShortestPath.Models
{
    public class FibonacciHeapVertex<TKey, TValue> : IMinHeapVertex<TKey, TValue>
    {
        public FibonacciHeapVertex(FibonacciHeap<TKey, TValue> heap, TKey key, TValue value)
        {
            Heap = heap;
            Key = key;
            Value = value;
        }

        private FibonacciHeap<TKey, TValue> Heap { get; }

        internal FibonacciHeapVertex<TKey, TValue> Parent { get; set; }

        internal FibonacciHeapVertex<TKey, TValue> Child { get; set; }

        internal FibonacciHeapVertex<TKey, TValue> Left { get; set; }

        internal FibonacciHeapVertex<TKey, TValue> Right { get; set; }

        internal bool IsMarked { get; set; }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int Degree { get; set; }

        public void DecreaseKey(TKey key)
        {
            if (Heap.Comparer.Compare(key, Key) > 0)
                throw new ArgumentException("The specified key is greater than the current key.", nameof(key));

            if (Right == null)
                throw new InvalidOperationException("This heap vertex is invalid.");

            Key = key;

            if (Parent != null && Heap.Comparer.Compare(Key, Parent.Key) < 0)
            {
                Cut();

                CascadingCut();
            }

            if (Heap.Comparer.Compare(Key, Heap.Min.Key) < 0) Heap.Min = this;
        }

        private void CascadingCut()
        {
            // If the parent of this heap vertex is null, then return.
            if (Parent == null) return;

            // If the parent of this heap vertex is not marked, then mark it and return.
            if (!Parent.IsMarked)
            {
                Parent.IsMarked = true;

                return;
            }

            // Cuts this heap vertex from its parent.
            Cut();

            // Recurses the cascading cut operation with the parent of this heap vertex.
            Parent.CascadingCut();
        }

        private void Cut()
        {
            if (Parent == null) throw new InvalidOperationException("This heap vertex does not have a parent.");

            Left.Right = Right;
            Right.Left = Left;

            if (Parent.Child == this) Parent.Child = Right;

            Parent.Degree--;

            if (Parent.Degree == 0) Parent.Child = null;

            Heap.Insert(this);

            Parent = null;

            IsMarked = false;
        }
    }
}