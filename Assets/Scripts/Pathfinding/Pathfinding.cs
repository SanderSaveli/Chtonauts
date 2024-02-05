using System.Collections.Generic;

namespace IUP.Toolkits.Pathfinding
{
    public static class Pathfinding
    {
        public static PathfindingResult<TValue> FindPath<TValue>(
            TValue startNodeValue,
            IPathGraph<TValue> pathGraph)
        {
            int iterCount = 0;
            PathNode<TValue> startNode = new(startNodeValue, 0);

            HashSet<IPathNode<TValue>> reachable = new() { startNode };
            HashSet<IPathNode<TValue>> explored = new();

            while (reachable.Count != 0)
            {
                IPathNode<TValue> node = pathGraph.ChooseNode(reachable);
                if (++iterCount >= 10000)
                {
                    return PathfindingResult<TValue>.PathNotFound;
                }
                if (pathGraph.IsPathFound(node))
                {
                    return BuildPath(node);
                }
                _ = reachable.Remove(node);
                _ = explored.Add(node);

                IEnumerable<IPathNode<TValue>> adjacentNodes = pathGraph.GetAdjacentNodes(node);

                foreach (IPathNode<TValue> adjacentNode in adjacentNodes)
                {
                    if (!explored.Contains(adjacentNode))
                    {
                        _ = reachable.Add(adjacentNode);
                    }

                    int cost = pathGraph.GetPathCost(node, adjacentNode);
                    cost += node.Cost;
                    if (cost < adjacentNode.Cost)
                    {
                        adjacentNode.PreviousNode = node;
                        adjacentNode.Cost = cost;
                    }
                }
            }
            return PathfindingResult<TValue>.PathNotFound;
        }

        private static PathfindingResult<TValue> BuildPath<TValue>(IPathNode<TValue> node)
        {
            List<IPathNode<TValue>> path = new();
            while (node.PreviousNode != null)
            {
                path.Add(node);
                node = node.PreviousNode;
            }
            path.Reverse();
            return new PathfindingResult<TValue>(path);
        }
    }
}
