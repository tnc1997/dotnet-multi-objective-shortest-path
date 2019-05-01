using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedGraph<TVertex, TEdge> : IWeightedGraph<TVertex, TEdge>, IDirectedGraph<TVertex>
    {
        /// <summary>
        ///     Returns all the edges that enter a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the edges that enter of.</param>
        /// <returns>The edges that enter the vertex.</returns>
        IEnumerable<TEdge> Inedges(TVertex vertex);

        /// <summary>
        ///     Returns all the edges that leave a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the edges that leave of.</param>
        /// <returns>The edges that leave the vertex.</returns>
        IEnumerable<TEdge> Outedges(TVertex vertex);

        /// <summary>
        ///     Returns all the endpoints that are adjacent to a vertex and can be reached by traversing an incoming edge against
        ///     its direction.
        /// </summary>
        /// <param name="vertex">
        ///     The vertex to get the endpoints that are adjacent to and can be reached by traversing an incoming
        ///     edge against its direction.
        /// </param>
        /// <returns>
        ///     The endpoints that are adjacent to the vertex and can be reached by traversing an incoming edge against its
        ///     direction.
        /// </returns>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> PredecessorEndpoints(TVertex vertex);

        /// <summary>
        ///     Returns all the endpoints that are adjacent to a vertex and can be reached by traversing an outgoing edge in its
        ///     direction.
        /// </summary>
        /// <param name="vertex">
        ///     The vertex to get the endpoints that are adjacent to and can be reached by traversing an outgoing
        ///     edge in its direction.
        /// </param>
        /// <returns>
        ///     The endpoints that are adjacent to the vertex and can be reached by traversing an outgoing edge in its
        ///     direction.
        /// </returns>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> SuccessorEndpoints(TVertex vertex);
    }
}