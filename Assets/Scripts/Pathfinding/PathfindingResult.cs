using System.Collections.Generic;

namespace IUP.Toolkits.Pathfinding
{
    public readonly struct PathfindingResult<TValue>
    {
        public static PathfindingResult<TValue> PathNotFound => new();

        public PathfindingResult(IReadOnlyList<IPathNode<TValue>> path) => Path = path;

        public readonly bool PathFound => Path != null;
        public readonly int PathCost => Path[Path.Count - 1].Cost;
        public readonly IReadOnlyList<IPathNode<TValue>> Path { get; }
    }
}
