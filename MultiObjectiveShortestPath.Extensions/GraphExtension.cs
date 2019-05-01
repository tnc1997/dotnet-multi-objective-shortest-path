using System;
using System.Collections.Generic;
using System.Linq;
using MultiObjectiveShortestPath.Models;

namespace MultiObjectiveShortestPath.Extensions
{
    public static class GraphExtension
    {
        public static IEnumerable<IUnweightedDirectedPath<TVertex>> AllSimplePaths<TVertex>(
            this IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin,
            TVertex destination,
            int maxDepth = int.MaxValue
        )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();
            if (!graph.Vertices.Contains(destination)) throw new ArgumentException();

            var visited = new Stack<TVertex>();
            var paths = new HashSet<IUnweightedDirectedPath<TVertex>>();

            visited.Push(origin);

            var stack = new Stack<Tuple<TVertex, Queue<IUnweightedEndpoint<TVertex>>>>();

            stack.Push(new Tuple<TVertex, Queue<IUnweightedEndpoint<TVertex>>>(
                origin,
                graph.SuccessorEndpoints(origin).ToQueue()
            ));

            while (stack.Count > 0)
            {
                var (vertex, successorEndpoints) = stack.Peek();

                if (Equals(vertex, destination) || successorEndpoints.Count == 0 || stack.Count > maxDepth)
                {
                    if (Equals(vertex, destination))
                    {
                        var unweightedDirectedPath = new UnweightedDirectedPath<TVertex>(
                            graph,
                            origin,
                            destination,
                            new Stack<TVertex>(visited)
                        );

                        paths.Add(unweightedDirectedPath);
                    }

                    visited.Pop();

                    stack.Pop();
                }
                else
                {
                    var successorEndpoint = successorEndpoints.Dequeue();

                    visited.Push(successorEndpoint.Vertex);

                    bool Predicate(IUnweightedEndpoint<TVertex> grandchildEndpoint)
                    {
                        return !visited.Contains(grandchildEndpoint.Vertex);
                    }

                    stack.Push(new Tuple<TVertex, Queue<IUnweightedEndpoint<TVertex>>>(
                        successorEndpoint.Vertex,
                        graph.SuccessorEndpoints(successorEndpoint.Vertex).Where(Predicate).ToQueue()
                    ));
                }
            }

            return paths;
        }

        public static IEnumerable<IWeightedDirectedPath<TVertex, TEdge>> AllSimplePaths<TVertex, TEdge>(
            this IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            int maxDepth = int.MaxValue
        )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();
            if (!graph.Vertices.Contains(destination)) throw new ArgumentException();

            return graph.AllSimplePaths(origin, destination, Adder<TEdge>.Default, maxDepth);
        }

        public static IEnumerable<IWeightedDirectedPath<TVertex, TEdge>> AllSimplePaths<TVertex, TEdge>(
            this IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            IAdder<TEdge> adder,
            int maxDepth = int.MaxValue
        )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (adder == null) throw new ArgumentNullException(nameof(adder));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();
            if (!graph.Vertices.Contains(destination)) throw new ArgumentException();

            var visitedVertices = new Stack<TVertex>();
            var visitedEdges = new Stack<TEdge>();
            var paths = new HashSet<IWeightedDirectedPath<TVertex, TEdge>>();

            visitedVertices.Push(origin);

            var stack = new Stack<Tuple<TVertex, Queue<IWeightedEndpoint<TVertex, TEdge>>>>();

            stack.Push(new Tuple<TVertex, Queue<IWeightedEndpoint<TVertex, TEdge>>>(
                origin,
                graph.SuccessorEndpoints(origin).ToQueue()
            ));

            while (stack.Count > 0)
            {
                var (vertex, successorEndpoints) = stack.Peek();

                if (Equals(vertex, destination) || successorEndpoints.Count == 0 || stack.Count > maxDepth)
                {
                    if (Equals(vertex, destination))
                    {
                        var weightedDirectedPath = new WeightedDirectedPath<TVertex, TEdge>(
                            graph,
                            origin,
                            destination,
                            new Stack<TVertex>(visitedVertices),
                            new Stack<TEdge>(visitedEdges),
                            visitedEdges.Aggregate(adder.Add)
                        );

                        paths.Add(weightedDirectedPath);
                    }

                    if (visitedVertices.Count > 0) visitedVertices.Pop();
                    if (visitedEdges.Count > 0) visitedEdges.Pop();

                    stack.Pop();
                }
                else
                {
                    var successorEndpoint = successorEndpoints.Dequeue();

                    visitedVertices.Push(successorEndpoint.Vertex);
                    visitedEdges.Push(successorEndpoint.Edge);

                    bool Predicate(IWeightedEndpoint<TVertex, TEdge> grandchildEndpoint)
                    {
                        return !visitedVertices.Contains(grandchildEndpoint.Vertex);
                    }

                    stack.Push(new Tuple<TVertex, Queue<IWeightedEndpoint<TVertex, TEdge>>>(
                        successorEndpoint.Vertex,
                        graph.SuccessorEndpoints(successorEndpoint.Vertex).Where(Predicate).ToQueue()
                    ));
                }
            }

            return paths;
        }

        public static IUnweightedDirectedGraph<TVertex> BreadthFirstSearch<TVertex>(
            this IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin
        )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            var visited = new HashSet<TVertex>();
            var output = new UnweightedDirectedGraph<TVertex>();

            var queue = new Queue<TVertex>();

            visited.Add(origin);
            queue.Enqueue(origin);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                bool Predicate(TVertex successorVertex)
                {
                    return !visited.Contains(successorVertex);
                }

                foreach (var successorVertex in graph.SuccessorVertices(vertex).Where(Predicate))
                {
                    output.AddEdge(vertex, successorVertex);

                    visited.Add(successorVertex);
                    queue.Enqueue(successorVertex);
                }
            }

            return output;
        }

        public static IUnweightedDirectedGraph<TVertex> DepthFirstSearch<TVertex>(
            this IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin
        )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            var visited = new HashSet<TVertex>();
            var output = new UnweightedDirectedGraph<TVertex>();

            var stack = new Stack<TVertex>();

            visited.Add(origin);
            stack.Push(origin);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                bool Predicate(TVertex successorVertex)
                {
                    return !visited.Contains(successorVertex);
                }

                foreach (var successorVertex in graph.SuccessorVertices(vertex).Where(Predicate))
                {
                    output.AddEdge(vertex, successorVertex);

                    visited.Add(successorVertex);
                    stack.Push(successorVertex);
                }
            }

            return output;
        }

        public static IDictionary<TVertex, IWeightedDirectedGraph<TVertex, TEdge>>
            DijkstraShortestPaths<TVertex, TEdge>(
                this IWeightedDirectedGraph<TVertex, TEdge> graph,
                TVertex origin
            )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            return graph.DijkstraShortestPaths(origin, Adder<TEdge>.Default, Comparer<TEdge>.Default);
        }

        public static IDictionary<TVertex, IWeightedDirectedGraph<TVertex, TEdge>>
            DijkstraShortestPaths<TVertex, TEdge>(
                this IWeightedDirectedGraph<TVertex, TEdge> graph,
                TVertex origin,
                IAdder<TEdge> adder
            )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (adder == null) throw new ArgumentNullException(nameof(adder));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            return graph.DijkstraShortestPaths(origin, adder, Comparer<TEdge>.Default);
        }

        public static IDictionary<TVertex, IWeightedDirectedGraph<TVertex, TEdge>>
            DijkstraShortestPaths<TVertex, TEdge>(
                this IWeightedDirectedGraph<TVertex, TEdge> graph,
                TVertex origin,
                IComparer<TEdge> comparer
            )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            return graph.DijkstraShortestPaths(origin, Adder<TEdge>.Default, comparer);
        }

        public static IDictionary<TVertex, IWeightedDirectedGraph<TVertex, TEdge>>
            DijkstraShortestPaths<TVertex, TEdge>(
                this IWeightedDirectedGraph<TVertex, TEdge> graph,
                TVertex origin,
                IAdder<TEdge> adder,
                IComparer<TEdge> comparer
            )
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (adder == null) throw new ArgumentNullException(nameof(adder));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            if (!graph.Vertices.Contains(origin)) throw new ArgumentException();

            // Constructs a dictionary which stores the graphs which contain the shortest path from the origin to
            // each of the vertices that is reachable from the origin by iteratively traversing successor endpoints.
            var graphs = new Dictionary<TVertex, IWeightedDirectedGraph<TVertex, TEdge>>();

            // Constructs a dictionary which stores the additions which represent the added edges which in turn
            // represent the shortest path from the origin to each of the vertices when added.
            var accumulations = new Dictionary<TVertex, TEdge>();

            var settledVertices = new HashSet<TVertex>();
            var unsettledVertices = new HashSet<TVertex> {origin};

            while (unsettledVertices.Count > 0)
            {
                // Returns the unsettled vertex that is nearest to the origin by finding the shortest of all the
                // accumulated edges which form a path from the origin to each of the unsettled vertices. Calling
                // the `MinBy` method with only one unsettled vertex in the set of unsettled vertices will return
                // that unsettled vertex, hence it will always return the origin during the first iteration over
                // the unsettled vertices set, because the unsettled vertices set will only contain the origin.
                var nearestVertex = unsettledVertices.MinBy(vertex => accumulations[vertex], comparer);

                // Removes the nearest vertex from the set of unvisited vertices.
                unsettledVertices.Remove(nearestVertex);

                // Iterates over each of the successor endpoints of the nearest vertex.
                foreach (var endpoint in graph.SuccessorEndpoints(nearestVertex))
                {
                    // If the vertex of the endpoint is already settled, then continue to the next iteration.
                    if (settledVertices.Contains(endpoint.Vertex)) continue;

                    // If the dictionary of additions contains an addition for the nearest vertex, then add this
                    // addition and the endpoint edge together in order to calculate a single path from the origin
                    // to the endpoint vertex of the current iteration; otherwise, an addition for the nearest vertex
                    // does not exist so return the endpoint edge without adding.
                    var currentPath = accumulations.ContainsKey(nearestVertex)
                        ? adder.Add(accumulations[nearestVertex], endpoint.Edge)
                        : endpoint.Edge;

                    // Returns true if the dictionary of additions contains the endpoint vertex and the current path
                    // is less than the existing shortest path from the origin to the endpoint vertex; otherwise,
                    // false. The existing shortest path is taken from the addition of each of the endpoints from
                    // the origin to the endpoint vertex which represent the existing shortest path when added.
                    bool IsCurrentPathLessThanShortestPath()
                    {
                        return accumulations.ContainsKey(endpoint.Vertex) &&
                               comparer.Compare(currentPath, accumulations[endpoint.Vertex]) < 0;
                    }

                    // If the dictionary of graphs does not contain a graph for the endpoint vertex or the current
                    // path is less than the existing shortest path, then update the graph of the endpoint vertex.
                    if (!graphs.ContainsKey(endpoint.Vertex) || IsCurrentPathLessThanShortestPath())
                    {
                        // If the dictionary of graphs contains a graph for the nearest vertex, then a shortest path
                        // from the origin to the nearest vertex already exists so return a copy of this graph;
                        // otherwise, such a shortest path does not exist so return a new empty graph.
                        var currentGraph = graphs.ContainsKey(nearestVertex)
                            ? graphs[nearestVertex].EndpointPairs.ToGraph()
                            : new WeightedDirectedGraph<TVertex, TEdge>();

                        // Adds an edge from the nearest vertex to the vertex of the endpoint. This means that the
                        // graph will now contain endpoint pairs from the origin to the endpoint vertex.
                        currentGraph.AddEdge(nearestVertex, endpoint.Vertex, endpoint.Edge);

                        // Updates the graph of the endpoint vertex with the current graph because the current graph
                        // contains a shorter path from the origin to the endpoint vertex than the existing graph.
                        graphs[endpoint.Vertex] = currentGraph;

                        // Updates the addition of the endpoint vertex with the current path for the same reason.
                        accumulations[endpoint.Vertex] = currentPath;
                    }

                    // Adds the endpoint vertex to the set of unsettled vertices.
                    unsettledVertices.Add(endpoint.Vertex);
                }

                // Adds the nearest vertex to the set of settled vertices.
                settledVertices.Add(nearestVertex);
            }

            return graphs;
        }

        public static IUnweightedEndpoint<TVertex> ToEndpoint<TVertex>(
            this IUnweightedEndpointPair<TVertex> endpointPair
        )
        {
            return new UnweightedEndpoint<TVertex>(endpointPair.Destination);
        }

        public static IWeightedEndpoint<TVertex, TEdge> ToEndpoint<TVertex, TEdge>(
            this IWeightedEndpointPair<TVertex, TEdge> endpointPair
        )
        {
            return new WeightedEndpoint<TVertex, TEdge>(endpointPair.Destination, endpointPair.Edge);
        }

        public static IUnweightedEndpointPair<TVertex> ToEndpointPair<TVertex>(
            this IUnweightedEndpoint<TVertex> endpoint,
            TVertex origin
        )
        {
            return new UnweightedEndpointPair<TVertex>(origin, endpoint.Vertex);
        }

        public static IWeightedEndpointPair<TVertex, TEdge> ToEndpointPair<TVertex, TEdge>(
            this IWeightedEndpoint<TVertex, TEdge> endpoint,
            TVertex origin
        )
        {
            return new WeightedEndpointPair<TVertex, TEdge>(origin, endpoint.Vertex, endpoint.Edge);
        }

        public static IUnweightedDirectedGraph<TVertex> ToGraph<TVertex>(
            this IEnumerable<IUnweightedEndpointPair<TVertex>> endpointPairs
        )
        {
            var graph = new UnweightedDirectedGraph<TVertex>();

            foreach (var endpointPair in endpointPairs) graph.AddEdge(endpointPair.Origin, endpointPair.Destination);

            return graph;
        }

        public static IWeightedDirectedGraph<TVertex, TEdge> ToGraph<TVertex, TEdge>(
            this IEnumerable<IWeightedEndpointPair<TVertex, TEdge>> endpointPairs
        )
        {
            var graph = new WeightedDirectedGraph<TVertex, TEdge>();

            foreach (var endpointPair in endpointPairs)
                graph.AddEdge(endpointPair.Origin, endpointPair.Destination, endpointPair.Edge);

            return graph;
        }
    }
}