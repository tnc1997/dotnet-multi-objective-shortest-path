namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedEndpointPair<TVertex, TEdge> : IEndpointPair<TVertex>
    {
        TEdge Edge { get; }
    }
}