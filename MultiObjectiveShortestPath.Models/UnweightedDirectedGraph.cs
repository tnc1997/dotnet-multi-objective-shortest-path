using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedDirectedGraph<TVertex> :
        GraphBase<TVertex, UnweightedDirectedVertexConnectionCollection<TVertex>>, IUnweightedDirectedGraph<TVertex>
    {
        public IEnumerable<IUnweightedEndpointPair<TVertex>> EndpointPairs => VertexConnectionCollections
            .SelectMany(UnweightedEndpointPairsSelector);

        public void AddEdge(TVertex origin, TVertex destination)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!VertexConnectionCollections.ContainsKey(origin)) AddVertex(origin);
            if (!VertexConnectionCollections.ContainsKey(destination)) AddVertex(destination);

            VertexConnectionCollections[origin].AddSuccessor(destination);
            VertexConnectionCollections[destination].AddPredecessor(origin);
        }

        public IEnumerable<IUnweightedEndpoint<TVertex>> AdjacentEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].AdjacentEndpoints;
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

        public IEnumerable<IUnweightedEndpoint<TVertex>> PredecessorEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].PredecessorEndpoints;
        }

        public IEnumerable<IUnweightedEndpoint<TVertex>> SuccessorEndpoints(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].SuccessorEndpoints;
        }

        private static IEnumerable<IUnweightedEndpointPair<TVertex>> UnweightedEndpointPairsSelector(
            KeyValuePair<TVertex, UnweightedDirectedVertexConnectionCollection<TVertex>> pair
        )
        {
            IUnweightedEndpointPair<TVertex> UnweightedEndpointPairSelector(
                IUnweightedEndpoint<TVertex> endpoint
            )
            {
                return new UnweightedEndpointPair<TVertex>(pair.Key, endpoint.Vertex);
            }

            return pair.Value.SuccessorEndpoints.Select(UnweightedEndpointPairSelector);
        }
    }
}