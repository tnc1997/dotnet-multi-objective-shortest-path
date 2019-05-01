using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedVertexConnectionCollection<TVertex, TEdge> :
        IWeightedVertexConnectionCollection<TVertex, TEdge>, IDirectedVertexConnectionCollection<TVertex>
    {
        /// <summary>
        ///     Gets all the edges that enter.
        /// </summary>
        IEnumerable<TEdge> Inedges { get; }

        /// <summary>
        ///     Gets all the edges that leave.
        /// </summary>
        IEnumerable<TEdge> Outedges { get; }

        /// <summary>
        ///     Gets all the endpoints that can be reached by traversing an incoming edge against its direction.
        /// </summary>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> PredecessorEndpoints { get; }

        /// <summary>
        ///     Gets all the endpoints that can be reached by traversing an outgoing edge in its direction.
        /// </summary>
        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> SuccessorEndpoints { get; }

        /// <summary>
        ///     Adds a vertex, with an edge, as a predecessor.
        /// </summary>
        /// <param name="vertex">The vertex to add as a predecessor.</param>
        /// <param name="edge">The edge to add between the vertices.</param>
        void AddPredecessor(TVertex vertex, TEdge edge);

        /// <summary>
        ///     Adds a vertex, with an edge, as a successor.
        /// </summary>
        /// <param name="vertex">The vertex to add as a successor.</param>
        /// <param name="edge">The edge to add between the vertices.</param>
        void AddSuccessor(TVertex vertex, TEdge edge);
    }
}