using System.Threading.Tasks;
using MultiObjectiveShortestPath.Apps.Console.Models;
using MultiObjectiveShortestPath.Models;

namespace MultiObjectiveShortestPath.Apps.Console.Services
{
    public interface IGraphService
    {
        Task<IUnweightedDirectedGraph<string>> GetUnweightedDirectedGraphAsync();

        Task<IWeightedDirectedGraph<string, Edge>> GetWeightedDirectedGraphAsync();
    }
}