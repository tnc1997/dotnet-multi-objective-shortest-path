namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedPathCollection<TVertex> : IUnweightedPathCollection<TVertex>,
        IDirectedPathCollection<TVertex>
    {
        IUnweightedDirectedPath<TVertex> Path(TVertex destination);
    }
}