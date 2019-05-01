using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IVertexConnectionCollection<TVertex> : IEnumerable<TVertex>
    {
        /// <summary>
        ///     Gets all the vertices that share an incident edge.
        /// </summary>
        IEnumerable<TVertex> AdjacentVertices { get; }

        /// <summary>
        ///     Gets the number of incident edges.
        /// </summary>
        int Degree { get; }
    }
}