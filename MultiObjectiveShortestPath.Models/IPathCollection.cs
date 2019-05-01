using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IPathCollection<TVertex> : IEnumerable<IPath<TVertex>>
    {
        TVertex Origin { get; }
    }
}