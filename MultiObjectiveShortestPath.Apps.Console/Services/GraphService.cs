using System.Threading.Tasks;
using MultiObjectiveShortestPath.Apps.Console.Models;
using MultiObjectiveShortestPath.Models;

namespace MultiObjectiveShortestPath.Apps.Console.Services
{
    public class GraphService : IGraphService
    {
        public GraphService(IEdgeService edgeService)
        {
            EdgeService = edgeService;
        }

        private IEdgeService EdgeService { get; }

        public async Task<IUnweightedDirectedGraph<string>> GetUnweightedDirectedGraphAsync()
        {
            var edges = await EdgeService.GetEdgesAsync();

            var graph = new UnweightedDirectedGraph<string>();

            foreach (var edge in edges) graph.AddEdge(edge.Origin, edge.Destination);

            return graph;
        }

        public async Task<IWeightedDirectedGraph<string, Edge>> GetWeightedDirectedGraphAsync()
        {
            var edges = await EdgeService.GetEdgesAsync();

            var graph = new WeightedDirectedGraph<string, Edge>();

            foreach (var edge in edges) graph.AddEdge(edge.Origin, edge.Destination, edge);

            return graph;
        }
    }
}