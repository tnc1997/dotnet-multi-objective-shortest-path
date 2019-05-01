namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedPathAlgorithm<TVertex> : IUnweightedPathAlgorithm<TVertex>,
        IDirectedPathAlgorithm<TVertex>
    {
        IUnweightedDirectedPath<TVertex> Path(TVertex origin, TVertex destination);

        IUnweightedDirectedPathCollection<TVertex> PathCollection(TVertex origin);
    }
}