using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedVertexConnectionCollection<TVertex> : IVertexConnectionCollection<TVertex>
    {
        /// <summary>
        ///     Gets all the endpoints that share an incident edge.
        /// </summary>
        IEnumerable<IUnweightedEndpoint<TVertex>> AdjacentEndpoints { get; }
    }
}