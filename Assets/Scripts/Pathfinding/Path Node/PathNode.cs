namespace IUP.Toolkits.Pathfinding
{
    public sealed class PathNode<TValue> : IPathNode<TValue>
    {
        public PathNode(TValue value, int cost = 0, IPathNode<TValue> previousNode = default)
        {
            Value = value;
            Cost = cost;
            PreviousNode = previousNode;
        }

        public TValue Value { get; set; }
        public IPathNode<TValue> PreviousNode { get; set; }
        public int Cost { get; set; }
    }
}
