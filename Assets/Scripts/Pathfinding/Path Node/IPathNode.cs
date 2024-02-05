namespace IUP.Toolkits.Pathfinding
{
    public interface IPathNode<TValue>
    {
        public IPathNode<TValue> PreviousNode { get; set; }
        public TValue Value { get; set; }
        public int Cost { get; set; }
    }
}
