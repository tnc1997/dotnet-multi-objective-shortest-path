using System.Collections;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class PathCollectionBase<TVertex> : IPathCollection<TVertex>
    {
        protected PathCollectionBase(IGraph<TVertex> graph, TVertex origin)
        {
            Graph = graph;
            Origin = origin;
        }

        private IGraph<TVertex> Graph { get; }

        public abstract IEnumerator<IPath<TVertex>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TVertex Origin { get; }
    }
}