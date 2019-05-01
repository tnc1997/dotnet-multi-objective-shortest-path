using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IPath<TVertex> : IEnumerable<TVertex>
    {
        TVertex Origin { get; }

        TVertex Destination { get; }

        IEnumerable<TVertex> Vertices { get; }
    }
}