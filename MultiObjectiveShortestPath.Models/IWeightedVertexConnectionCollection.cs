using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedVertexConnectionCollection<TVertex, TEdge> : IVertexConnectionCollection<TVertex>
    {
        /// <summary>
        ///     Gets all the endpoints that share an incident edge.
        /// </summary>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> AdjacentEndpoints { get; }

        /// <summary>
        ///     Gets all the edges that are incident.
        /// </summary>
        IEnumerable<TEdge> IncidentEdges { get; }

        /// <summary>
        ///     Returns all the edges that are incident to a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the edges that are incident of.</param>
        /// <returns>The edges that are incident to the vertex.</returns>
        IEnumerable<TEdge> IncidentEdgesConnecting(TVertex vertex);
    }
}