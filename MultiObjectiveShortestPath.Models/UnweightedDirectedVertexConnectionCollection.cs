using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedDirectedVertexConnectionCollection<TVertex> : VertexConnectionCollectionBase<TVertex>,
        IUnweightedDirectedVertexConnectionCollection<TVertex>
    {
        public UnweightedDirectedVertexConnectionCollection()
        {
            PredecessorVertexCollection = new List<TVertex>();
            SuccessorVertexCollection = new List<TVertex>();
        }

        private ICollection<TVertex> PredecessorVertexCollection { get; }

        private ICollection<TVertex> SuccessorVertexCollection { get; }

        public override IEnumerable<TVertex> AdjacentVertices => PredecessorVertices.Concat(SuccessorVertices);

        public override int Degree => Indegree + Outdegree;

        public IEnumerable<IUnweightedEndpoint<TVertex>> AdjacentEndpoints =>
            PredecessorEndpoints.Concat(SuccessorEndpoints);

        public int Indegree => PredecessorVertices.Count();

        public int Outdegree => SuccessorVertices.Count();

        public IEnumerable<TVertex> PredecessorVertices => PredecessorVertexCollection;

        public IEnumerable<TVertex> SuccessorVertices => SuccessorVertexCollection;

        public IEnumerable<IUnweightedEndpoint<TVertex>> PredecessorEndpoints =>
            PredecessorVertexCollection.Select(UnweightedEndpointSelector);

        public IEnumerable<IUnweightedEndpoint<TVertex>> SuccessorEndpoints =>
            SuccessorVertexCollection.Select(UnweightedEndpointSelector);

        public void AddPredecessor(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            PredecessorVertexCollection.Add(vertex);
        }

        public void AddSuccessor(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            SuccessorVertexCollection.Add(vertex);
        }

        private static IUnweightedEndpoint<TVertex> UnweightedEndpointSelector(TVertex vertex)
        {
            return new UnweightedEndpoint<TVertex>(vertex);
        }
    }
}