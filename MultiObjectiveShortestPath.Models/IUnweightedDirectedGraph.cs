using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedGraph<TVertex> : IUnweightedGraph<TVertex>, IDirectedGraph<TVertex>
    {
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
        IEnumerable<IUnweightedEndpoint<TVertex>> PredecessorEndpoints(TVertex vertex);

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
        IEnumerable<IUnweightedEndpoint<TVertex>> SuccessorEndpoints(TVertex vertex);
    }
}