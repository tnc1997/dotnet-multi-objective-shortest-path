using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedGraph<TVertex, TEdge> : IGraph<TVertex>
    {
        /// <summary>
        ///     Gets all the edges.
        /// </summary>
        IEnumerable<TEdge> Edges { get; }

        /// <summary>
        ///     Gets all the endpoint pairs.
        /// </summary>
        IEnumerable<IWeightedEndpointPair<TVertex, TEdge>> EndpointPairs { get; }

        /// <summary>
        ///     Adds an edge from an origin to a destination.
        /// </summary>
        /// <param name="origin">The origin vertex of the edge.</param>
        /// <param name="destination">The destination vertex of the edge.</param>
        /// <param name="edge">The edge to add between the origin and the destination.</param>
        void AddEdge(TVertex origin, TVertex destination, TEdge edge);

        /// <summary>
        ///     Returns all the endpoints that share an incident edge with a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the endpoints that share an incident edge with.</param>
        /// <returns>The endpoints that share an incident edge with the vertex.</returns>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> AdjacentEndpoints(TVertex vertex);

        /// <summary>
        ///     Returns all the edges that are incident to a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the edges that are incident to.</param>
        /// <returns>The edges that are incident to the vertex.</returns>
        IEnumerable<TEdge> IncidentEdges(TVertex vertex);

        /// <summary>
        ///     Returns all the edges that connect an origin and a destination.
        /// </summary>
        /// <param name="origin">The origin vertex.</param>
        /// <param name="destination">The destination vertex.</param>
        /// <returns>The edges that connect the origin and the destination.</returns>
        IEnumerable<TEdge> IncidentEdgesConnecting(TVertex origin, TVertex destination);
    }
}