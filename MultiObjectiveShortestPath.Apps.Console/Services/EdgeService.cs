using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MultiObjectiveShortestPath.Apps.Console.Models;
using Newtonsoft.Json;

namespace MultiObjectiveShortestPath.Apps.Console.Services
{
    public class EdgeService : IEdgeService
    {
        public async Task<IEnumerable<Edge>> GetEdgesAsync()
        {
            using (var streamReader = File.OpenText($@"{AppDomain.CurrentDomain.BaseDirectory}Inputs\Edges.json"))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var json = new JsonSerializer().Deserialize<IEnumerable<Edge>>(jsonTextReader);

                return await Task.FromResult(json);
            }
        }
    }
}