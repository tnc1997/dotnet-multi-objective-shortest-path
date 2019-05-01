using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IUnweightedDirectedVertexConnectionCollection<TVertex> :
        IUnweightedVertexConnectionCollection<TVertex>, IDirectedVertexConnectionCollection<TVertex>
    {
        /// <summary>
        ///     Gets all the endpoints that can be reached by traversing an incoming edge against its direction.
        /// </summary>
        IEnumerable<IUnweightedEndpoint<TVertex>> PredecessorEndpoints { get; }

        /// <summary>
        ///     Gets all the endpoints that can be reached by traversing an outgoing edge in its direction.
        /// </summary>
        IEnumerable<IUnweightedEndpoint<TVertex>> SuccessorEndpoints { get; }

        /// <summary>
        ///     Adds a vertex as a predecessor.
        /// </summary>
        /// <param name="vertex">The vertex to add as a predecessor.</param>
        void AddPredecessor(TVertex vertex);

        /// <summary>
        ///     Adds a vertex as a successor.
        /// </summary>
        /// <param name="vertex">The vertex to add as a successor.</param>
        void AddSuccessor(TVertex vertex);
    }
}