using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedDirectedDirectedPathCollection<TVertex, TEdge> : PathCollectionBase<TVertex>,
        IWeightedDirectedPathCollection<TVertex, TEdge>
    {
        public WeightedDirectedDirectedPathCollection(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            IDictionary<TVertex, Tuple<TEdge, TEdge>> edges
        ) : this(graph, origin, edges, Adder<TEdge>.Default)
        {
        }

        public WeightedDirectedDirectedPathCollection(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            IDictionary<TVertex, Tuple<TEdge, TEdge>> edges,
            IAdder<TEdge> adder
        ) : base(graph, origin)
        {
            Graph = graph;
            Edges = edges;
            Adder = adder;
        }

        private IWeightedDirectedGraph<TVertex, TEdge> Graph { get; }

        private IDictionary<TVertex, Tuple<TEdge, TEdge>> Edges { get; }

        private IAdder<TEdge> Adder { get; }

        public override IEnumerator<IPath<TVertex>> GetEnumerator()
        {
            return Edges.Keys.Select(Path).GetEnumerator();
        }

        public IWeightedDirectedPath<TVertex, TEdge> Path(TVertex destination)
        {
            if (Equals(Origin, destination)) return new WeightedDirectedPath<TVertex, TEdge>(Graph, Origin);

            if (!Edges.ContainsKey(destination) || Equals(Edges[destination].Item1, default(TEdge))) return null;

            var edges = new LinkedList<TEdge>();
            var vertices = new LinkedList<TVertex>();

            var current = destination;
            var weight = default(TEdge);

            while (Edges.ContainsKey(current))
            {
                var inedge = Edges[current].Item2;

                if (inedge == null) break;

                edges.AddFirst(inedge);
                vertices.AddFirst(current);

                bool Predicate(IWeightedEndpoint<TVertex, TEdge> endpoint)
                {
                    return Equals(endpoint.Edge, inedge);
                }

                current = Graph.PredecessorEndpoints(current).Single(Predicate).Vertex;
                weight = Adder.Add(weight, inedge);
            }

            vertices.AddFirst(current);

            return new WeightedDirectedPath<TVertex, TEdge>(Graph, Origin, destination, vertices, edges, weight);
        }
    }
}