using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedDirectedVertexConnectionCollection<TVertex, TEdge> :
        VertexConnectionCollectionBase<TVertex>, IWeightedDirectedVertexConnectionCollection<TVertex, TEdge>
    {
        public WeightedDirectedVertexConnectionCollection()
        {
            InedgeCollections = new Dictionary<TVertex, ICollection<TEdge>>();
            OutedgeCollections = new Dictionary<TVertex, ICollection<TEdge>>();
        }

        private IDictionary<TVertex, ICollection<TEdge>> InedgeCollections { get; }

        private IDictionary<TVertex, ICollection<TEdge>> OutedgeCollections { get; }

        public override IEnumerable<TVertex> AdjacentVertices => PredecessorVertices.Concat(SuccessorVertices);

        public override int Degree => Indegree + Outdegree;

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> AdjacentEndpoints =>
            PredecessorEndpoints.Concat(SuccessorEndpoints);

        public IEnumerable<TEdge> IncidentEdges => Inedges.Concat(Outedges);

        public IEnumerable<TEdge> IncidentEdgesConnecting(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            var incidentEdges = new List<TEdge>();

            if (InedgeCollections.ContainsKey(vertex)) incidentEdges.AddRange(InedgeCollections[vertex]);

            if (OutedgeCollections.ContainsKey(vertex)) incidentEdges.AddRange(OutedgeCollections[vertex]);

            return incidentEdges;
        }

        public int Indegree => Inedges.Count();

        public int Outdegree => Outedges.Count();

        public IEnumerable<TVertex> PredecessorVertices => InedgeCollections.Keys;

        public IEnumerable<TVertex> SuccessorVertices => OutedgeCollections.Keys;

        public IEnumerable<TEdge> Inedges => InedgeCollections.Values.SelectMany(edges => edges);

        public IEnumerable<TEdge> Outedges => OutedgeCollections.Values.SelectMany(edges => edges);

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> PredecessorEndpoints =>
            InedgeCollections.SelectMany(WeightedEndpointsSelector);

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> SuccessorEndpoints =>
            OutedgeCollections.SelectMany(WeightedEndpointsSelector);

        public void AddPredecessor(TVertex vertex, TEdge edge)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));
            if (edge == null) throw new ArgumentNullException(nameof(edge));

            if (!InedgeCollections.ContainsKey(vertex)) InedgeCollections[vertex] = new List<TEdge>();

            InedgeCollections[vertex].Add(edge);
        }

        public void AddSuccessor(TVertex vertex, TEdge edge)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));
            if (edge == null) throw new ArgumentNullException(nameof(edge));

            if (!OutedgeCollections.ContainsKey(vertex)) OutedgeCollections[vertex] = new List<TEdge>();

            OutedgeCollections[vertex].Add(edge);
        }

        private static IEnumerable<IWeightedEndpoint<TVertex, TEdge>> WeightedEndpointsSelector(
            KeyValuePair<TVertex, ICollection<TEdge>> pair
        )
        {
            return pair.Value.Select(edge => new WeightedEndpoint<TVertex, TEdge>(pair.Key, edge));
        }
    }
}