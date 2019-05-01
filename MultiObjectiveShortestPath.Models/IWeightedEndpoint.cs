namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedEndpoint<TVertex, TEdge> : IEndpoint<TVertex>
    {
        TEdge Edge { get; }
    }
}