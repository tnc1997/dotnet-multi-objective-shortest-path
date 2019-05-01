namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedPathCollection<TVertex, TEdge> : IWeightedPathCollection<TVertex, TEdge>,
        IDirectedPathCollection<TVertex>
    {
        IWeightedDirectedPath<TVertex, TEdge> Path(TVertex destination);
    }
}