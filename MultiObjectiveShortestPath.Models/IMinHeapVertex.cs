namespace MultiObjectiveShortestPath.Models
{
    public interface IMinHeapVertex<TKey, TValue> : IHeapVertex<TKey, TValue>
    {
        void DecreaseKey(TKey key);
    }
}