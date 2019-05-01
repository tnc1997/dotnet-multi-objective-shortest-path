using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MultiObjectiveShortestPath.Apps.Console.Adders;
using MultiObjectiveShortestPath.Apps.Console.Comparers;
using MultiObjectiveShortestPath.Apps.Console.Models;
using MultiObjectiveShortestPath.Apps.Console.Services;
using MultiObjectiveShortestPath.Extensions;
using MultiObjectiveShortestPath.Models;
using Newtonsoft.Json;
using static System.Console;
using static System.IO.Directory;
using static System.Math;
using static System.StringComparer;
using static Newtonsoft.Json.Formatting;
using static Newtonsoft.Json.JsonSerializer;

namespace MultiObjectiveShortestPath.Apps.Console
{
    public class Program
    {
        private static EdgeService EdgeService { get; }
        private static GraphService GraphService { get; }
        
        private static EdgeAdder EdgeAdder { get; }
        private static EdgeComparer EdgeComparer { get; }
        
        private static IUnweightedDirectedGraph<string> UnweightedDirectedGraph { get; set; }
        private static IWeightedDirectedGraph<string, Edge> WeightedDirectedGraph { get; set; }
        
        private static Stopwatch Stopwatch { get; }

        static Program()
        {
            EdgeService = new EdgeService();
            GraphService = new GraphService(EdgeService);

            EdgeAdder = new EdgeAdder();
            EdgeComparer = new EdgeComparer();

            Stopwatch = new Stopwatch();
        }

        public static async Task Main(string[] args)
        {
            UnweightedDirectedGraph = await GraphService.GetUnweightedDirectedGraphAsync();
            WeightedDirectedGraph = await GraphService.GetWeightedDirectedGraphAsync();

            if (args != null && args.Contains("debug", OrdinalIgnoreCase)) DoDebug();

            CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}Outputs");

            var settings = new JsonSerializerSettings {Formatting = Indented};
            var serializer = Create(settings);

            string path;

            #region Weighted Sum Algorithm

            Write("Weighted Sum Algorithm? (Y/N) ");

            if (ReadLine() == "Y")
            {
                var allSimplePaths = WeightedDirectedGraph.AllSimplePaths(
                    "HARROW & WEALDSTONE",
                    "ELEPHANT & CASTLE",
                    EdgeAdder,
                    25
                ).ToList();

                var weights = new Dictionary<ObjectiveType, double>
                {
                    {ObjectiveType.Comfortability, 100},
                    {ObjectiveType.Reliability, 50}
                };

                var weightedSumAlgorithmResults = new List<WeightedSumAlgorithmResult>();

                for (var noOfPaths = 100; noOfPaths < allSimplePaths.Count; noOfPaths += 100)
                {
                    var times = new List<double>();

                    for (var i = 0; i < 100; i++)
                    {
                        Stopwatch.Restart();
                        allSimplePaths
                            .Take(noOfPaths)
                            .WeightedSumShortestPath(weights, WeightedSumShortestPathObjectiveSelector);
                        Stopwatch.Stop();

                        times.Add(Stopwatch.Elapsed.TotalMilliseconds);
                    }

                    var weightedSumAlgorithmResult = new WeightedSumAlgorithmResult(
                        times.Average(),
                        noOfPaths
                    );

                    weightedSumAlgorithmResults.Add(weightedSumAlgorithmResult);
                }

                path = $@"{AppDomain.CurrentDomain.BaseDirectory}Outputs\WeightedSumAlgorithmResults.json";
                using (var file = File.CreateText(path))
                {
                    serializer.Serialize(file, weightedSumAlgorithmResults);
                }
            }

            #endregion

            #region Dijkstra's Algorithm

            Write("Dijkstra's Algorithm? (Y/N) ");

            if (ReadLine() == "Y")
            {
                var dijkstraAlgorithm = new DijkstraShortestWeightedDirectedPathAlgorithm<string, Edge>(
                    WeightedDirectedGraph,
                    EdgeAdder,
                    EdgeComparer
                );

                var dijkstraAlgorithmResults = new List<DijkstraAlgorithmResult>();

                foreach (var destination in WeightedDirectedGraph.Vertices.TakeLast(200))
                {
                    var times = new List<double>();
                    var pathDistances = new List<double>();
                    var pathTimes = new List<double>();

                    for (var i = 0; i < 10000; i++)
                    {
                        EdgeComparer.NoOfTotalComparisons = 0;
                        EdgeComparer.NoOfInteractiveComparisons = 0;

                        Stopwatch.Restart();
                        var weightedDirectedPath = dijkstraAlgorithm.Path("HARROW & WEALDSTONE", destination);
                        Stopwatch.Stop();

                        times.Add(Stopwatch.Elapsed.TotalMilliseconds);
                        pathDistances.Add(weightedDirectedPath.Weight.Distance);
                        pathTimes.Add(weightedDirectedPath.Weight.Time.TotalMinutes);
                    }

                    var dijkstraAlgorithmResult = new DijkstraAlgorithmResult(
                        times.Average(),
                        EdgeComparer.NoOfInteractiveComparisons,
                        EdgeComparer.NoOfTotalComparisons,
                        pathDistances.Average(),
                        pathTimes.Average()
                    );

                    dijkstraAlgorithmResults.Add(dijkstraAlgorithmResult);
                }

                path = $@"{AppDomain.CurrentDomain.BaseDirectory}Outputs\DijkstraAlgorithmResults.json";
                using (var file = File.CreateText(path))
                {
                    serializer.Serialize(file, dijkstraAlgorithmResults);
                }
            }

            #endregion

            #region Genetic Algorithm

            Write("Genetic Algorithm? (Y/N) ");

            if (ReadLine() == "Y")
            {
                var exactSolution = new DijkstraShortestWeightedDirectedPathAlgorithm<string, Edge>(
                    WeightedDirectedGraph,
                    EdgeAdder,
                    EdgeComparer
                ).Path("HARROW & WEALDSTONE", "ELEPHANT & CASTLE").Weight;

                var geneticAlgorithmResults = new List<GeneticAlgorithmResult>();

                for (var noOfGenerations = 50; noOfGenerations < 550; noOfGenerations += 50)
                for (var mutationProbability = 0; mutationProbability < 110; mutationProbability += 10)
                {
                    var accuracies = new List<double>();
                    var times = new List<double>();

                    for (var i = 0; i < 10; i++)
                    {
                        EdgeComparer.NoOfTotalComparisons = 0;
                        EdgeComparer.NoOfInteractiveComparisons = 0;

                        var geneticAlgorithm = new PathGeneticAlgorithm<string, Edge>(
                            noOfGenerations,
                            50,
                            100,
                            mutationProbability / 100d,
                            WeightedDirectedGraph,
                            "HARROW & WEALDSTONE",
                            "ELEPHANT & CASTLE",
                            EdgeAdder,
                            EdgeComparer
                        );

                        geneticAlgorithm.Evolve();

                        var approximateSolution = geneticAlgorithm.FittestChromosome.Weight;

                        accuracies.Add(
                            1 - (
                                Abs((exactSolution.Distance - approximateSolution.Distance) / exactSolution.Distance) +
                                Abs((exactSolution.Time - approximateSolution.Time) / exactSolution.Time) +
                                Abs((exactSolution.Comfortability - approximateSolution.Comfortability) /
                                    exactSolution.Comfortability) +
                                Abs((exactSolution.Reliability - approximateSolution.Reliability) /
                                    exactSolution.Reliability)
                            )
                        );

                        times.Add(geneticAlgorithm.Time.TotalSeconds);
                    }

                    var geneticAlgorithmResult = new GeneticAlgorithmResult(
                        times.Average(),
                        noOfGenerations,
                        mutationProbability / 100d,
                        accuracies.Average()
                    );

                    geneticAlgorithmResults.Add(geneticAlgorithmResult);
                }

                path = $@"{AppDomain.CurrentDomain.BaseDirectory}Outputs\GeneticAlgorithmResults.json";
                using (var file = File.CreateText(path))
                {
                    serializer.Serialize(file, geneticAlgorithmResults);
                }
            }

            #endregion
        }

        private static void DoDebug()
        {
            #region Miscellaneous Algorithms

            WriteLine("All Simple Paths - Default");
            Stopwatch.Restart();
            var allSimplePaths = WeightedDirectedGraph.AllSimplePaths(
                "HARROW & WEALDSTONE",
                "ELEPHANT & CASTLE",
                EdgeAdder,
                25
            );
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Breadth First Search - Default");
            Stopwatch.Restart();
            UnweightedDirectedGraph.BreadthFirstSearch(
                "HARROW & WEALDSTONE"
            );
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Breadth First Search - Graph Enumerator");
            Stopwatch.Restart();
            new BreadthFirstSearchGraphEnumerator<string>(
                UnweightedDirectedGraph,
                "HARROW & WEALDSTONE"
            ).ToEnumerable();
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Breadth First Search - Path Algorithm");
            Stopwatch.Restart();
            new BreadthFirstSearchUnweightedDirectedPathAlgorithm<string>(
                UnweightedDirectedGraph
            ).PathCollection("HARROW & WEALDSTONE");
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Depth First Search - Default");
            Stopwatch.Restart();
            UnweightedDirectedGraph.DepthFirstSearch(
                "HARROW & WEALDSTONE"
            );
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Depth First Search - Graph Enumerator");
            Stopwatch.Restart();
            new DepthFirstSearchGraphEnumerator<string>(
                UnweightedDirectedGraph,
                "HARROW & WEALDSTONE"
            ).ToEnumerable();
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Depth First Search - Path Algorithm");
            Stopwatch.Restart();
            new DepthFirstSearchUnweightedDirectedPathAlgorithm<string>(
                UnweightedDirectedGraph
            ).PathCollection("HARROW & WEALDSTONE");
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");
            
            #endregion

            #region Weighted Sum Algorithm

            var allSimplePathsList = allSimplePaths.ToList();

            var extremizeTypes = new Dictionary<ObjectiveType, ExtremizeType>
            {
                {ObjectiveType.Time, ExtremizeType.Minimize},
                {ObjectiveType.Distance, ExtremizeType.Minimize},
                {ObjectiveType.Comfortability, ExtremizeType.Maximize},
                {ObjectiveType.Reliability, ExtremizeType.Maximize},
                {ObjectiveType.Connections, ExtremizeType.Minimize}
            };

            var weights = new Dictionary<ObjectiveType, double>
            {
                {ObjectiveType.Comfortability, 100},
                {ObjectiveType.Reliability, 50}
            };

            WriteLine("Weighted Sum Shortest Path - Default");
            Stopwatch.Restart();
            allSimplePathsList.WeightedSumShortestPath(weights, WeightedSumShortestPathObjectiveSelector);
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            WriteLine("Weighted Sum Shortest Paths - Default");
            Stopwatch.Restart();
            allSimplePathsList.WeightedSumShortestPaths(extremizeTypes, WeightedSumShortestPathsObjectiveSelector);
            Stopwatch.Stop();
            WriteLine($"Time: {Stopwatch.Elapsed}\n");

            #endregion

            #region Dijkstra's Algorithm

            EdgeComparer.NoOfTotalComparisons = 0;
            EdgeComparer.NoOfInteractiveComparisons = 0;

            WriteLine("Dijkstra Shortest Paths - Default");
            Stopwatch.Restart();
            WeightedDirectedGraph.DijkstraShortestPaths(
                "HARROW & WEALDSTONE",
                EdgeAdder,
                EdgeComparer
            );
            Stopwatch.Stop();
            WriteLine(
                $"Time: {Stopwatch.Elapsed}, Interactive Comparisons: {EdgeComparer.NoOfInteractiveComparisons}, Total Comparisons: {EdgeComparer.NoOfTotalComparisons}\n"
            );

            EdgeComparer.NoOfTotalComparisons = 0;
            EdgeComparer.NoOfInteractiveComparisons = 0;

            WriteLine("Dijkstra Shortest Paths - Path Algorithm");
            Stopwatch.Restart();
            new DijkstraShortestWeightedDirectedPathAlgorithm<string, Edge>(
                WeightedDirectedGraph,
                EdgeAdder,
                EdgeComparer
            ).PathCollection("HARROW & WEALDSTONE");
            Stopwatch.Stop();
            WriteLine(
                $"Time: {Stopwatch.Elapsed}, Interactive Comparisons: {EdgeComparer.NoOfInteractiveComparisons}, Total Comparisons: {EdgeComparer.NoOfTotalComparisons}\n"
            );

            #endregion
        }

        private static IDictionary<ObjectiveType, double> WeightedSumShortestPathObjectiveSelector(
            IWeightedDirectedPath<string, Edge> weightedDirectedPath
        )
        {
            return WeightedSumShortestPathObjectiveSelector(
                weightedDirectedPath,
                weightedDirectedPath.Vertices.Count()
            );
        }

        private static IDictionary<ObjectiveType, double> WeightedSumShortestPathObjectiveSelector(
            IWeightedDirectedPath<string, Edge> weightedDirectedPath,
            int noOfEdges
        )
        {
            return new Dictionary<ObjectiveType, double>
            {
                {ObjectiveType.Comfortability, weightedDirectedPath.Weight.Comfortability / noOfEdges},
                {ObjectiveType.Reliability, weightedDirectedPath.Weight.Reliability / noOfEdges}
            };
        }

        private static IDictionary<ObjectiveType, double> WeightedSumShortestPathsObjectiveSelector(
            IWeightedDirectedPath<string, Edge> weightedDirectedPath
        )
        {
            return WeightedSumShortestPathsObjectiveSelector(
                weightedDirectedPath,
                weightedDirectedPath.Vertices.Count()
            );
        }

        private static IDictionary<ObjectiveType, double> WeightedSumShortestPathsObjectiveSelector(
            IWeightedDirectedPath<string, Edge> weightedDirectedPath,
            int noOfEdges
        )
        {
            return new Dictionary<ObjectiveType, double>
            {
                {ObjectiveType.Time, weightedDirectedPath.Weight.Time.TotalMinutes},
                {ObjectiveType.Distance, weightedDirectedPath.Weight.Distance},
                {ObjectiveType.Comfortability, weightedDirectedPath.Weight.Comfortability / noOfEdges},
                {ObjectiveType.Reliability, weightedDirectedPath.Weight.Reliability / noOfEdges},
                {ObjectiveType.Connections, weightedDirectedPath.Edges.DistinctBy(edge => edge.Line).Count() - 1}
            };
        }
    }
}