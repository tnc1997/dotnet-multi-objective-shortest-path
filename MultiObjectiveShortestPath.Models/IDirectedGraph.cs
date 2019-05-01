using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IDirectedGraph<TVertex> : IGraph<TVertex>
    {
        /// <summary>
        ///     Returns the number of inedges of a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the number of inedges of.</param>
        /// <returns>The number of inedges of the vertex.</returns>
        int Indegree(TVertex vertex);

        /// <summary>
        ///     Returns the number of outedges of a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the number of outedges of.</param>
        /// <returns>The number of outedges of the vertex.</returns>
        int Outdegree(TVertex vertex);

        /// <summary>
        ///     Returns all the vertices that are adjacent to a vertex and can be reached by traversing an incoming edge against
        ///     its direction.
        /// </summary>
        /// <param name="vertex">
        ///     The vertex to get the vertices that are adjacent to and can be reached by traversing an incoming
        ///     edge against its direction.
        /// </param>
        /// <returns>
        ///     The vertices that are adjacent to the vertex and can be reached by traversing an incoming edge against its
        ///     direction.
        /// </returns>
        IEnumerable<TVertex> PredecessorVertices(TVertex vertex);

        /// <summary>
        ///     Returns all the vertices that are adjacent to a vertex and can be reached by traversing an outgoing edge in its
        ///     direction.
        /// </summary>
        /// <param name="vertex">
        ///     The vertex to get the vertices that are adjacent to and can be reached by traversing an outgoing
        ///     edge in its direction.
        /// </param>
        /// <returns>
        ///     The vertices that are adjacent to the vertex and can be reached by traversing an outgoing edge in its
        ///     direction.
        /// </returns>
        IEnumerable<TVertex> SuccessorVertices(TVertex vertex);
    }
}