namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedPath<TVertex> : IUnweightedPath<TVertex>, IDirectedPath<TVertex>
    {
    }
}