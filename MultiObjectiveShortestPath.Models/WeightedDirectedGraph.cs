using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedDirectedGraph<TVertex, TEdge> :
        GraphBase<TVertex, WeightedDirectedVertexConnectionCollection<TVertex, TEdge>>,
        IWeightedDirectedGraph<TVertex, TEdge>
    {
        public IEnumerable<TEdge> Edges => VertexConnectionCollections.Values
            .SelectMany(collection => collection.Outedges);

        public IEnumerable<IWeightedEndpointPair<TVertex, TEdge>> EndpointPairs => VertexConnectionCollections
            .SelectMany(WeightedEndpointPairsSelector);

        public void AddEdge(TVertex origin, TVertex destination, TEdge edge)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (edge == null) throw new ArgumentNullException(nameof(edge));

            if (!VertexConnectionCollections.ContainsKey(origin)) AddVertex(origin);
            if (!VertexConnectionCollections.ContainsKey(destination)) AddVertex(destination);

            VertexConnectionCollections[origin].AddSuccessor(destination, edge);
            VertexConnectionCollections[destination].AddPredecessor(origin, edge);
        }

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> AdjacentEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].AdjacentEndpoints;
        }

        public IEnumerable<TEdge> IncidentEdges(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].IncidentEdges;
        }

        public IEnumerable<TEdge> IncidentEdgesConnecting(TVertex origin, TVertex destination)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!VertexConnectionCollections.ContainsKey(origin)) throw new ArgumentException();
            if (!VertexConnectionCollections.ContainsKey(destination)) throw new ArgumentException();

            return VertexConnectionCollections[origin].IncidentEdgesConnecting(destination);
        }

        public int Indegree(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].Indegree;
        }

        public int Outdegree(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].Outdegree;
        }

        public IEnumerable<TVertex> PredecessorVertices(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].PredecessorVertices;
        }

        public IEnumerable<TVertex> SuccessorVertices(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].SuccessorVertices;
        }

        public IEnumerable<TEdge> Inedges(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].Inedges;
        }

        public IEnumerable<TEdge> Outedges(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].Outedges;
        }

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> PredecessorEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].PredecessorEndpoints;
        }

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> SuccessorEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].SuccessorEndpoints;
        }

        private static IEnumerable<IWeightedEndpointPair<TVertex, TEdge>> WeightedEndpointPairsSelector(
            KeyValuePair<TVertex, WeightedDirectedVertexConnectionCollection<TVertex, TEdge>> pair
        )
        {
            IWeightedEndpointPair<TVertex, TEdge> WeightedEndpointPairSelector(
                IWeightedEndpoint<TVertex, TEdge> endpoint
            )
            {
                return new WeightedEndpointPair<TVertex, TEdge>(pair.Key, endpoint.Vertex, endpoint.Edge);
            }

            return pair.Value.SuccessorEndpoints.Select(WeightedEndpointPairSelector);
        }
    }
}