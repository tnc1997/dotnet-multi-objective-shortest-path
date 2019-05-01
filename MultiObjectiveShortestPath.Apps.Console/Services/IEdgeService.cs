using System.Collections.Generic;
using System.Threading.Tasks;
using MultiObjectiveShortestPath.Apps.Console.Models;

namespace MultiObjectiveShortestPath.Apps.Console.Services
{
    public interface IEdgeService
    {
        Task<IEnumerable<Edge>> GetEdgesAsync();
    }
}