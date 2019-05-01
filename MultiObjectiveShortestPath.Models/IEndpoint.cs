namespace MultiObjectiveShortestPath.Models
{
    public interface IEndpoint<TVertex>
    {
        TVertex Vertex { get; }
    }
}