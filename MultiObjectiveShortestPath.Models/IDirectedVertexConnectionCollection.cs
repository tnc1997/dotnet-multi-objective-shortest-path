using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IDirectedVertexConnectionCollection<TVertex> : IVertexConnectionCollection<TVertex>
    {
        /// <summary>
        ///     Gets the number of inedges.
        /// </summary>
        int Indegree { get; }

        /// <summary>
        ///     Gets the number of outedges.
        /// </summary>
        int Outdegree { get; }

        /// <summary>
        ///     Gets all the vertices that can be reached by traversing an incoming edge against its direction.
        /// </summary>
        IEnumerable<TVertex> PredecessorVertices { get; }

        /// <summary>
        ///     Gets all the vertices that can be reached by traversing an outgoing edge in its direction.
        /// </summary>
        IEnumerable<TVertex> SuccessorVertices { get; }
    }
}