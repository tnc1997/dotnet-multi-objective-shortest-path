namespace MultiObjectiveShortestPath.Models
{
    public interface IEndpointPair<TVertex>
    {
        TVertex Origin { get; }

        TVertex Destination { get; }
    }
}