namespace MultiObjectiveShortestPath.Models
{
    public interface IHeap<TKey, TValue>
    {
        int Count { get; }

        bool IsEmpty { get; }

        void Clear();
    }
}