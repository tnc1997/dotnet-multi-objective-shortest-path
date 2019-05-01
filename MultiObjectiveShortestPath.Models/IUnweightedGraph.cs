using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedGraph<TVertex> : IGraph<TVertex>
    {
        /// <summary>
        ///     Gets all the endpoint pairs.
        /// </summary>
        IEnumerable<IUnweightedEndpointPair<TVertex>> EndpointPairs { get; }

        /// <summary>
        ///     Adds an edge from an origin to a destination.
        /// </summary>
        /// <param name="origin">The origin vertex of the edge.</param>
        /// <param name="destination">The destination vertex of the edge.</param>
        void AddEdge(TVertex origin, TVertex destination);

        /// <summary>
        ///     Returns all the endpoints that share an incident edge with a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the endpoints that share an incident edge with.</param>
        /// <returns>The endpoints that share an incident edge with the vertex.</returns>
        IEnumerable<IUnweightedEndpoint<TVertex>> AdjacentEndpoints(TVertex vertex);
    }
}