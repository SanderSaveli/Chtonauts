public interface IManaPool
{
    public int AvailableMana { get; }
    public int PoolSize { get; set;  }

    public float CurrentMana { get; set; }
    public float ManaPerSecondIncrease { get; set; }    
    public bool TrySpendMana(int count);
}
