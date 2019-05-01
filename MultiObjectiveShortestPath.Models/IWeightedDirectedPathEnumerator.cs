namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedPathEnumerator<TVertex, TEdge> : IWeightedPathEnumerator<TVertex, TEdge>,
        IDirectedPathEnumerator<TVertex>
    {
        IWeightedDirectedPathCollection<TVertex, TEdge> PathCollection();
    }
}