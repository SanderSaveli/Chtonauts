using System.Collections.Generic;

namespace IUP.Toolkits.Pathfinding
{
    public interface IPathGraph<TValue>
    {
        public bool IsPathFound(IPathNode<TValue> node);

        public IPathNode<TValue> ChooseNode(IEnumerable<IPathNode<TValue>> reachable);

        public IEnumerable<IPathNode<TValue>> GetAdjacentNodes(IPathNode<TValue> node);

        public int GetPathCost(IPathNode<TValue> origin, IPathNode<TValue> source);
    }
}
