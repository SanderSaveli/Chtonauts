public interface IManaService : IService
{
    public float currentMana { get; }
    public float currentManaIncrease { get; }
    public int maxMana { get; }

    public bool TrySpendMana(int count);
}
