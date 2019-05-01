namespace MultiObjectiveShortestPath.Models
{
    public interface IHeapVertex<TKey, TValue>
    {
        TKey Key { get; }

        TValue Value { get; }

        int Degree { get; }
    }
}