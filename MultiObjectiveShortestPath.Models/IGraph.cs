using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IGraph<TVertex> : IEnumerable<TVertex>
    {
        /// <summary>
        ///     Gets all the vertices.
        /// </summary>
        IEnumerable<TVertex> Vertices { get; }

        /// <summary>
        ///     Adds a vertex to the graph.
        /// </summary>
        /// <param name="vertex">The vertex to add to the graph.</param>
        void AddVertex(TVertex vertex);

        /// <summary>
        ///     Returns all the vertices that share an incident edge with a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the vertices that share an incident edge of.</param>
        /// <returns>The vertices that share an incident edge with the vertex.</returns>
        IEnumerable<TVertex> AdjacentVertices(TVertex vertex);

        /// <summary>
        ///     Returns the the number of incident edges of a vertex.
        /// </summary>
        /// <param name="vertex">The vertex to get the number of incident edges of.</param>
        /// <returns>The number of incident edges of the vertex.</returns>
        int Degree(TVertex vertex);
    }
}