namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedPathAlgorithm<TVertex, TEdge> : IWeightedPathAlgorithm<TVertex, TEdge>,
        IDirectedPathAlgorithm<TVertex>
    {
        IWeightedDirectedPath<TVertex, TEdge> Path(TVertex origin, TVertex destination);

        IWeightedDirectedPathCollection<TVertex, TEdge> PathCollection(TVertex origin);
    }
}