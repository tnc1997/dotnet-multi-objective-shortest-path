namespace MultiObjectiveShortestPath.Models
{
    public interface IMinHeap<TKey, TValue> : IHeap<TKey, TValue>
    {
        IMinHeapVertex<TKey, TValue> ExtractMin();

        IMinHeapVertex<TKey, TValue> FindMin();

        IMinHeapVertex<TKey, TValue> Insert(TKey key, TValue value);
    }
}