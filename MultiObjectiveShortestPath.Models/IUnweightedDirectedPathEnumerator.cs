namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedPathEnumerator<TVertex> : IUnweightedPathEnumerator<TVertex>,
        IDirectedPathEnumerator<TVertex>
    {
        IUnweightedDirectedPathCollection<TVertex> PathCollection();
    }
}